


##------------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------##

#!/usr/bin/env Rscript
rm(list=ls())


# 1. Set directory
tempwd <- 'C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts'
setwd(tempwd)
#Check: tempwd


# 2. Set library directory
.libPaths(paste0(tempwd, "/RLibraries"))
libLocation <- .libPaths()[1]
#Check: libLocation
print(libLocation)



# 3. Install packages to the designated package and libraries folder
#Retrieve list of all installed packages
listPack <- installed.packages(lib.loc = libLocation)[,"Package"]
#Check: listPack


#If package not found, it will be installed accordingly
if (!"RODBC" %in% listPack) {
  install.packages("RODBC", repos='http://cran.us.r-project.org', lib=libLocation,
				   destdir=(paste(tempwd,"\\RPackages", sep = "")))
  print("Installing package: RODBC")
}
if (!"forecast" %in% listPack) {
  install.packages("forecast", repos = c("http://rstudio.org/_packages", "http://cran.rstudio.com"), lib=libLocation,
				   destdir=(paste(tempwd,"\\RPackages", sep = "")))
  print("Installing package: forecast")
}




# 4. Initialize all the required libraries
library(RODBC, lib.loc=libLocation)
library(forecast, lib.loc=libLocation)





# 5. Retrieve all the list of items from the InventoryCatelogue and format into a vector
#Open connection
dbconnection <- odbcDriverConnect("Driver=ODBC Driver 11 for SQL Server;
								  Server=127.0.0.1; Database=SA45Team12AD; Uid=root; Pwd=password; trusted_connection=yes")

#Retrieving our list of items
listItems <- sqlQuery(dbconnection, "SELECT * FROM [SA45Team12AD].[dbo].[InventoryCatalogue] WHERE Discontinued = 'N'")

#Close connection
odbcClose(dbconnection)

#Formatting into a vector
flistItems <- as.vector(listItems$ItemID)




# 6. Processing each item in the list, one at a time...
for (x in 1:nrow(listItems)) {
  
  #Simple check
  check <- FALSE
  
  
  #Assign ID to a var
  tempID1 <- flistItems[x]
  tempName1 <- as.vector(listItems$Description)[x]
  
  
  # 7. Retrieving the entire list of past weekly demand for the current item
  #Open connection
  dbconnection <- odbcDriverConnect("Driver=ODBC Driver 11 for SQL Server;
								  Server=127.0.0.1; Database=SA45Team12AD; Uid=root; Pwd=password; trusted_connection=yes")
  
  #Retrieving our primary data
  sData <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[ActualDataByItem] @ItemID=", tempID1))
  
  #Checking total values retrieved are zero or less than 26 periods (aka a new or relatively new product - 26 weeks is apprx 6mths)
  if (nrow(sData) == 0 || nrow(sData) < 26) {
	
	#For such items, they will be compared to existing items in the database that already has a reasonable amt of past data 
	#and belong to a similar product category
	
	#Retrieve its categoryID
	itemCatID <- as.vector(listItems$CategoryID)[x]
	
	#Compare against those already in the list to identify any with a similar categoryID
	for (y in 1:nrow(listItems)) {
	  
	  #Ensure its not comparing against itself
	  if (x != y) {
		tempCatID <- as.vector(listItems$CategoryID)[y]
		
		if (itemCatID == tempCatID) {
		  
		  #If similar, will use the similar pdt's past data
		  sData <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[ActualDataByItem] @ItemID=", as.vector(listItems$ItemID)[y]))
		  
		  #If data is retrieved successfully (aka not null), then escape from the loop
		  if (nrow(sData) != 0) {
			
			#Retrieve the second item's ID and name
			tempID2 <- as.vector(listItems$ItemID)[y]
			tempName2 <- as.vector(listItems$Description)[y]
			
			#Retrieving earliest period from the earliest season
			ePeriod <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[Earliest_PnS] @ItemID=", tempID2))
			
			#Retrieving latest period from the latest season
			lPeriod <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[Latest_PnS] @ItemID=", tempID2))
			
			check <- TRUE
			break
		  }
		}
	  }
	}
  } else {
	#Retrieving earliest period from the earliest season
	ePeriod <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[Earliest_PnS] @ItemID=", tempID1))
	
	#Retrieving latest period from the latest season
	lPeriod <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[Latest_PnS] @ItemID=", tempID1))
  }
  
  
  #Close connection
  odbcClose(dbconnection)
  
  
  
  
  # 8. Formatting data into a ts object for easier manipulation
  tsData <- ts(sData, start=c(c(ePeriod$Season), c(ePeriod$Period)), frequency=52)   #Change freq to 52 for weeks
  #Check: plot(tsData)
  
  
  
  
  # 9. Performing our forecast using Automated ARIMA forecasting
  print("Starting forecasting algorithm...")
  fitData <- auto.arima(tsData)
  #auto.arima means letting the com decide on the best model for you. It does everything for you.
  
  #fitData    #Can see that R will use arima 2,1,2 to perform the focus
  
  #Determining the forecasted value
  resultF <- forecast(fitData, 5)
  
  #The accuracy() function will calculate the errors for the dataset. You can then analyse it. 
  #accuracy(fitData)
  
  #Plot data
  #The range gets wider over time cos its getting harder to predict the future the further down the road.
  #Check: plot(resultF, xlab="Year", ylab="Quantity", main="Forecasted Demand", type="l")
  
  
  
  
  # 10. Populating the forecasted values back to the database
  tempS <- c(lPeriod$Season)
  tempP <- c(lPeriod$Period)
  #If its the last wk of Dec (52th season), it will reset it back to zero and increase the year by 1. Change to 52 if using weeks.*
  if (tempP == 52) {
	tempP <- 0
	tempS <- tempS + 1
  }
  
  
  #Open connection
  dbconnection <- odbcDriverConnect("Driver=ODBC Driver 11 for SQL Server;
								  Server=127.0.0.1; Database=SA45Team12AD; Uid=root; Pwd=password; trusted_connection=yes")
  for (x in 1:5) {
	tM <- as.numeric(resultF$mean)
	tL <- as.numeric(resultF$lower)
	tH <- as.numeric(resultF$upper)
	
	#Add the week
	tempP <- tempP + 1
	
	#Querying the DB
	stmt <- sprintf('EXEC [SA45Team12AD].[dbo].[Insert_Forecast] @ItemID=%s, @varSeason=%d, @varPeriod=%d, @varDd=%f, @varLo80=%f, 
				  @varHi80=%f, @varLo95=%f, @varHi95=%f', tempID1, tempS, tempP, tM[x], tL[x], tH[x], tL[x + 5], tH[x + 5])
	sqlQuery(dbconnection, stmt)
  }
  odbcClose(dbconnection)  #Close connection
  
  
  
  if (check == FALSE) {
	print(paste0("Item ", tempName1, " was successfully processed."))
  } else {
	print(paste0("Item ", tempName1, " was successfully processed. [Using ", tempName2, "'s data]"))
  }
}

### END ###
print("Forecasting algorithm will now end...")
print("---------------------------END--------------------------------")
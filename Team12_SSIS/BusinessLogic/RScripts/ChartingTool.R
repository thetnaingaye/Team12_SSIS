


##------------------------------------------         SYED MOHAMAD KHAIRWANCYK BIN SAYED HIRWAINI         ---------------------------------------------##

#rm(list=ls())

## This here allows us to retrieve from cmd
args <- commandArgs(trailingOnly = TRUE)
itemID <- as.character(args[1])
seasonFrom <- as.numeric(args[2])
periodFrom <- as.numeric(args[3])
seasonTo <- as.numeric(args[4])
periodTo <- as.numeric(args[5])
numPeriods <- as.numeric(args[6])
typeOfChart <- as.numeric(args[7])



# 1. Set directory
tempwd <- 'C:/inetpub/wwwroot/Team12_SSIS/BusinessLogic/RScripts'
setwd(tempwd)
#Check: tempwd




# 2. Set library directory
.libPaths(paste0(tempwd, "/RLibraries"))
libLocation <- .libPaths()[1]
#Check: libLocation




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
if (!"gridExtra" %in% listPack) {
  install.packages("gridExtra", repos='http://cran.us.r-project.org', lib=libLocation,
                   destdir=(paste(tempwd,"\\RPackages", sep = "")))
  print("Installing package: gridExtra")
}





# 4. Initialize all the required libraries
library(RODBC, lib.loc=libLocation)
library(forecast, lib.loc=libLocation)
library(gridExtra, lib.loc=libLocation)
library(ggplot2, lib.loc=libLocation)








# 5. Retrieve all the list of items from the InventoryCatelogue and format into a vector
#Open connection
dbconnection <- odbcDriverConnect("Driver=ODBC Driver 11 for SQL Server;
                                  Server=127.0.0.1; Database=SA45Team12AD; Uid=root; Pwd=password; trusted_connection=yes")

#Retrieving our list of items
listItems <- sqlQuery(dbconnection, "SELECT * FROM [SA45Team12AD].[dbo].[InventoryCatalogue] WHERE Discontinued = 'N'")

#Close connection
odbcClose(dbconnection)






# 6. Identify item's position from the list
posn <- 0
for (x in 1:nrow(listItems)) {
  
  tempItemID <- as.vector(listItems$ItemID)[x]
  if (tempItemID == itemID)
  {
    posn <- x
    break
  }
}






# 7. Define key attrs
#Simple check
check <- FALSE

#Assign ID to a var
tempName1 <- as.vector(listItems$Description)[posn]







# 8. Retrieving the entire list of past weekly demand for the current item
#Open connection
dbconnection <- odbcDriverConnect("Driver=ODBC Driver 11 for SQL Server;
                                  Server=127.0.0.1; Database=SA45Team12AD; Uid=root; Pwd=password; trusted_connection=yes")

#Retrieving our primary data
sData <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[ActualDataByItemAndDate] @ItemID=", itemID, 
                                       ", @SeasonFrom=", seasonFrom, ", @PeriodFrom=", periodFrom,
                                       ", @SeasonTo=", seasonTo, ", @PeriodTo=", periodTo))

#Checking total values retrieved are zero or less than 26 periods (aka a new or relatively new product - 26 weeks is apprx 6mths)
if (nrow(sData) == 0 || nrow(sData) < 26) {
  
  #For such items, they will be compared to existing items in the database that already has a reasonable amt of past data 
  #and belong to a similar product category
  
  #Retrieve its categoryID
  itemCatID <- as.vector(listItems$CategoryID)[posn]
  
  #Compare against those already in the list to identify any with a similar categoryID
  for (y in 1:nrow(listItems)) {
    
    #Ensure its not comparing against itself
    if (posn != y) {
      tempCatID <- as.vector(listItems$CategoryID)[y]
      
      if (itemCatID == tempCatID) {
        
        #If similar, will use the similar pdt's past data
        sData <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[ActualDataByItemAndDate] @ItemID=", as.vector(listItems$ItemID)[y],
                                               ", @SeasonFrom=", seasonFrom, ", @PeriodFrom=", periodFrom,
                                               ", @SeasonTo=", seasonTo, ", @PeriodTo=", periodTo))
        
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
  ePeriod <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[Earliest_PnS] @ItemID=", itemID))
  
  #Retrieving latest period from the latest season
  lPeriod <- sqlQuery(dbconnection, paste0("EXEC [SA45Team12AD].[dbo].[Latest_PnS] @ItemID=", itemID))
}


#Close connection
odbcClose(dbconnection)







# 9. Formatting data into a ts object for easier manipulation
tsData <- ts(sData, start=c(c(seasonFrom), c(periodFrom)), frequency=52)   #Change freq to 52 for weeks
#Check: plot(tsData)







# 10. Performing our forecast using Automated ARIMA forecasting
fitData <- auto.arima(tsData)
#auto.arima means letting the com decide on the best model for you. It does everything for you.

#fitData    #Can see that R will use arima 2,1,2 to perform the focus

#Determining the forecasted value
resultF <- forecast(fitData, numPeriods)






# 11. Identify our dir to store our charts and table images
#Finding a dir to paste the html file
#imagedir <- paste(tempwd, "/Charts", sep="")
imagedir <- 'C:/inetpub/wwwroot/Team12_SSIS/Images/Charts'

#This method below does not crash when there is an existing dir. It just shows a warning [Good exception handler]
dir.create(file.path(imagedir), showWarnings = FALSE)






# 12. Creating our image.
#Specifying file name
imageFile <- 'chart1.png'

#Checking if file with specified name exist in the working directory, if it does, remove it
if(file.exists(imageFile)) file.remove(imageFile)

png(filename=paste(imagedir, "/", imageFile, sep=""), units="in", width=8, height=5, res=700)

# Choose the type of chart that you want.
if (typeOfChart == 1)
{
  plot(resultF, xlab="Year", ylab="Actual Demand", main=paste0("Forecasted Demand for ", tempName1), type = 'l')
}
if (typeOfChart == 2)
{
  plot(resultF, xlab="Year", ylab="Actual Demand", main=paste0("Forecasted Demand for ", tempName1), type = 'b')
}
if (typeOfChart == 3)
{
  plot(resultF, xlab="Year", ylab="Actual Demand", main=paste0("Forecasted Demand for ", tempName1), type = 's')
}
if (typeOfChart == 4)
{
  plot(resultF, xlab="Year", ylab="Actual Demand", main=paste0("Forecasted Demand for ", tempName1), type = 'h')
}

dev.off()





# 13. Creating our diff table images

# Our results table
tableName1 <- paste(imagedir, "/", "tableResults.png", sep="")

#Checking if file with specified name exist in the working directory, if it does, remove it
if(file.exists(tableName1)) file.remove(tableName1)

mydata <- data.frame(resultF)
mytable <- cbind(mydata)

# Creating a blank plot and then adding mytable to it
qplot(1:10, 1:10, geom = "blank") + theme_bw() + theme(line = element_blank(), text = element_blank()) + annotation_custom(grob = tableGrob(mytable))

tg = gridExtra::tableGrob(mytable)
h = grid::convertHeight(sum(tg$heights), "in", TRUE)
w = grid::convertWidth(sum(tg$widths), "in", TRUE)
ggplot2::ggsave(tableName1, tg, width=w, height=h)



# Our accuracy table
tableName2 <- paste(imagedir, "/", "tableAccuracy.png", sep="")

#Checking if file with specified name exist in the working directory, if it does, remove it
if(file.exists(tableName2)) file.remove(tableName2)

mydata <- data.frame(format(accuracy(resultF), digits = 2))
mytable <- cbind(mydata)

# Creating a blank plot and then adding mytable to it
qplot(1:10, 1:10, geom = "blank") + theme_bw() + theme(line = element_blank(), text = element_blank()) + annotation_custom(grob = tableGrob(mytable))

tg = gridExtra::tableGrob(mytable)
h = grid::convertHeight(sum(tg$heights), "in", TRUE)
w = grid::convertWidth(sum(tg$widths), "in", TRUE)
ggplot2::ggsave(tableName2, tg, width=w, height=h)




# Our model table
tableName3 <- paste(imagedir, "/", "tableModel.png", sep="")

#Checking if file with specified name exist in the working directory, if it does, remove it
if(file.exists(tableName3)) file.remove(tableName3)

mytable <- cbind(resultF$method)

# Creating a blank plot and then adding mytable to it
qplot(1:10, 1:10, geom = "blank") + theme_bw() + theme(line = element_blank(), text = element_blank()) + annotation_custom(grob = tableGrob(mytable))

tg = gridExtra::tableGrob(mytable)
h = grid::convertHeight(sum(tg$heights), "in", TRUE)
w = grid::convertWidth(sum(tg$widths), "in", TRUE)
ggplot2::ggsave(tableName3, tg, width=w, height=h)






### END ###
print("Chart has been sucessfully created. Thank you.")
print("---------------------------END--------------------------------")











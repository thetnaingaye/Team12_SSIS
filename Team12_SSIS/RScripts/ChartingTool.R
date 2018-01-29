

ChartTool <- function(tDir)
{
  #!/usr/bin/env Rscript
  rm(list=ls())
  
  
  # 1. Set directory
  tempwd <- tDir
  #setwd(tempwd)
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
  
  
  
  
  # 4. Initialize all the required libraries
  library(RODBC, lib.loc=libLocation)
  library(forecast, lib.loc=libLocation)
  
  
  
  
  
  
  #Finding a dir to paste the html file
  htmldir <- paste(Sys.getenv("HOME"), "\\R Analytics\\R-2-ASP\\Reporting\\Content\\html\\", sep="")
  htmldir <- paste(tempwd, "/html", sep="")
  htmldir
  
  
  #This method below does not crash when there is an existing dir. It just shows a warning [Good exception handler]
  dir.create(file.path(htmldir), showWarnings = FALSE)
  setwd(file.path(htmldir))
  
  #Specifying file name
  pageFile <- 'plotChart.html'
  imageFile <- 'chart.png'
  
  #Checking if file with specified name exist in the working directory, if it does, remove it
  if(file.exists(pageFile)) file.remove(pageFile)
  if(file.exists(imageFile)) file.remove(imageFile)
  
  png(filename=paste(tempwd, "/Charts/", imageFile, sep=""))   #Specify where the file is
  plot(tabc)
  dev.off()
  
  
}
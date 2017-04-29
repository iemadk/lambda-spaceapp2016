

library(lattice)
library(plyr)
Data<-data.frame()
## Create a record and some random data for every 5 seconds 
## over two days for two hosts.
dates <- seq(as.POSIXct("2014-01-01 00:00:00", tz = "GMT"),
             as.POSIXct("2017-01-01 23:59:55", tz = "GMT"),
             by = 600)
dates <- seq(as.POSIXct("2017-01-01 00:00:00", tz = "GMT"),
             as.POSIXct("2017-01-02 23:59:55", tz = "GMT"),
             by = 600)


hosts <- c(rep("host1", length(dates)), rep("host2", 
                                            length(dates)),rep("host3", length(dates)))
Areas_Index<-c(1000000,5001100,1200000,500000,400000,573000,1024000,1112425,10345432,2000000)
#MM<-sample(n=20,Areas)
for (i in 1:length(dates)) {
  x <- sample(Areas_Index, 1)
  # y<-c(x)
  y[i] <- as.numeric(x)
}
Area<-y

uv    <- runif(n = length(dates), min = 200, max = 400)#sample(200:400, 2*length(dates), replace = TRUE)
Data  <- data.frame(dates = dates, hosts = hosts, UV = uv,Area)
X<-nrow(Data)#<-runif(n = length(dates), min = 200, max = 290)
#Host1<-runif(n = length(dates), min = 200, max = 290)
#Data[1:288,3]<-Host1
Host1<-as.integer(runif(n = length(dates), min = 200, max = 290))
Host2<-as.integer(runif(n = length(dates), min = 291, max = 320))
Host3<-as.integer(runif(n = length(dates), min = 321, max = 400))
#######


## Calculate the mean for every hour using cut() to define 
## the factors and ddply() to calculate the means. 
## getmeans() is applied for each unique combination of the
## hosts and hour factors.
Data<-Small_Data_Sensor
#Data<-Big_Data_Sensor
######
Error_Index<-c(-1,0,1)
n<-nrow(Data)
Error<-sample(Error_Index,size = n,replace = TRUE)
Data$Error<-Error
TestData<-Data

TestData$UV <- ifelse(TestData$Error !=1, 0, TestData$UV)


#write.csv(Data,"Small_Data_Sensor.csv")
write.csv(Data,"Big_Data_Sensor.csv")
#####


################
getmeans  <- function(Df) c(UV = mean(Df$UV))
Data$hour <- cut(TestData$dates, breaks = "hour")
Means <- ddply(TestData, .(hosts, hour), getmeans)
Means$hour <- as.POSIXct(Means$hour, tz = "GMT")


TestData <- TestData[order(dates),] 

xyplot(UV ~ hour | hosts, data = Means, type = "o",
       scales = list(x = list(relation = "free", rot = 90)))

#############################
getmeans  <- function(Df) c(UV = mean(Df$UV))
Data$hour <- cut(Data$dates, breaks = "hour")
Means <- ddply(Data, .(hosts, hour), getmeans)
Means$hour <- as.POSIXct(Means$hour, tz = "GMT")
xyplot(UV ~ hour | hosts, data = Means, type = "o",
       scales = list(x = list(relation = "free", rot = 90)))
########################################

source("http://bioconductor.org/biocLite.R")
biocLite("rhdf5")
library(rhdf5)
Nasadata1 <- h5read("Nasa_data_1.he5")
mydata <- h5read("Nasa_data_1.he5", "/HDFEOS/GRIDS/OMI UVB Product/Data Fields")
mydata1 <- h5read("Nasa_data_1.he5", "/HDFEOS/GRIDS/OMI UVB Product/Data Fields")
DFDd<-as.data.frame(mydata)
# 
# h5ls("Nasa_data_1.he5")
# #Nasa_data_1.he5
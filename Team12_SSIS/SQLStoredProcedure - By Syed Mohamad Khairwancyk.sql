


			-- REQUISITION RECORDS TABLE --

-- 1. Retrieving list of PAST requisition records by department
--Regular sql expression
SELECT r.RequestID, r.RequestDate, r.DepartmentID, r.RequestorName, r.ApprovedDate, r.ApproverName, r.Remarks
FROM [SA45Team12AD].[dbo].[RequisitionRecords] r, [SA45Team12AD].[dbo].[Departments] d
WHERE r.DepartmentID = d.DeptID
AND d.DepartmentName = 'Computer Science'
AND r.RequestID IN (
					SELECT RequestID
					FROM RequisitionRecordDetails
					GROUP BY RequestID
					HAVING RequestID IN (            --Will show those are processed
										SELECT RequestID
										FROM RequisitionRecordDetails
										WHERE Status = 'Processed'
										)
					)
--Using stored procedure
CREATE PROCEDURE PastReqRecordsByDept (@DeptName NVARCHAR(100))
AS BEGIN
	SELECT r.RequestID, r.RequestDate, r.DepartmentID, r.RequestorName, r.ApprovedDate, r.ApproverName, r.Remarks
	FROM [SA45Team12AD].[dbo].[RequisitionRecords] r, [SA45Team12AD].[dbo].[Departments] d
	WHERE r.DepartmentID = d.DeptID
	AND d.DepartmentName = @DeptName
	AND r.RequestID IN (
					SELECT RequestID
					FROM RequisitionRecordDetails
					GROUP BY RequestID
					HAVING RequestID IN (      --Will show those only those that are ENITRELY (all items) processed.
										SELECT RequestID
										FROM RequisitionRecordDetails
										WHERE Status = 'Processed'
										)
					)
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[PastReqRecordsByDept] @DeptName = 'Computer Science'
	--To drop this sp,
	DROP PROCEDURE PastReqRecordsByDept

	



-- 2. Retrieving req records by status
--Regular sql expression
SELECT DISTINCT rr.RequestID, rr.RequestDate, rr.DepartmentID, rr.RequestorName, rr.ApprovedDate, rr.ApproverName, rr.Remarks
FROM RequisitionRecords rr, RequisitionRecordDetails rd
WHERE rr.RequestID = rd.RequestID
AND rr.RequestID IN (
					SELECT RequestID
					FROM RequisitionRecordDetails
					GROUP BY RequestID
					HAVING RequestID IN (            --Will show those not yet proccessed
										SELECT RequestID
										FROM RequisitionRecordDetails
										WHERE Status = 'Processed'
										)
					)
--Using stored procedure
CREATE PROCEDURE RetrieveRRByStatus (@Status NVARCHAR(100))
AS BEGIN
	SELECT DISTINCT rr.RequestID, rr.RequestDate, rr.DepartmentID, rr.RequestorName, rr.ApprovedDate, rr.ApproverName, rr.Remarks
FROM RequisitionRecords rr, RequisitionRecordDetails rd
WHERE rr.RequestID = rd.RequestID
AND rr.RequestID IN (
					SELECT RequestID
					FROM RequisitionRecordDetails
					GROUP BY RequestID
					HAVING RequestID IN (            --Will show those not yet proccessed
										SELECT RequestID
										FROM RequisitionRecordDetails
										WHERE Status = @Status
										)
					)
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[RetrieveRRByStatus] @Status = 'Processed'
	--To drop this sp,
	DROP PROCEDURE RetrieveRRByStatus


	
	EXEC [SA45Team12AD].[dbo].[RetrieveRRByStatus] @Status = 'Processed'
	





























			-- ACTUAL DATA TABLE --

--3. Retrieving all actual data by ItemID
--Regular sql exression
SELECT * FROM [SA45Team12AD].[dbo].[ActualData] WHERE ItemID = 'E032'
--Using stored procedure
CREATE PROCEDURE ActualDataByItem (@ItemID NVARCHAR(100))
AS BEGIN
	SELECT ActualDemand FROM [SA45Team12AD].[dbo].[ActualData] WHERE ItemID = @ItemID
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[ActualDataByItem] @ItemID = 'F032'
	--To drop this sp,
	DROP PROCEDURE ActualDataByItem

--ALTER TABLE Sheet1 ALTER COLUMN Year INTEGER NOT NULL
--ALTER TABLE Sheet1 ADD PRIMARY KEY (Year, Month)







--4. Retrieving all actual data by ItemID and two "date" range
--Regular sql exression
SELECT * FROM [SA45Team12AD].[dbo].[ActualData]
WHERE ItemID = 'C002'
AND Season BETWEEN 2015 AND 2017
AND AID NOT IN (
				SELECT AID FROM [SA45Team12AD].[dbo].[ActualData]
				WHERE ItemID = 'C002'
				AND SEASON <= 2015
				AND PERIOD < 10
				)
AND AID NOT IN (
				SELECT AID FROM [SA45Team12AD].[dbo].[ActualData]
				WHERE ItemID = 'C002'
				AND SEASON >= 2017
				AND PERIOD > 10
				)
ORDER BY Season, Period
--Using stored procedure
CREATE PROCEDURE ActualDataByItemAndDate (@ItemID NVARCHAR(100), @SeasonFrom INTEGER, @PeriodFrom INTEGER, @SeasonTo INTEGER, @PeriodTo INTEGER)
AS BEGIN
	SELECT ActualDemand FROM [SA45Team12AD].[dbo].[ActualData]
	WHERE ItemID = @ItemID
	AND Season BETWEEN @SeasonFrom AND @SeasonTo
	AND AID NOT IN (
					SELECT AID FROM [SA45Team12AD].[dbo].[ActualData]
					WHERE ItemID = @ItemID
					AND SEASON <= @SeasonFrom
					AND PERIOD < @PeriodFrom
					)
	AND AID NOT IN (
					SELECT AID FROM [SA45Team12AD].[dbo].[ActualData]
					WHERE ItemID = @ItemID
					AND SEASON >= @SeasonTo
					AND PERIOD > @PeriodTo
					)
	ORDER BY Season, Period
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[ActualDataByItemAndDate] @ItemID = 'F032', @SeasonFrom = 2015, @PeriodFrom = 10, @SeasonTo = 2017, @PeriodTo = 10
	--To drop this sp,
	DROP PROCEDURE ActualDataByItemAndDate









--5. Finding the earliest period from the earliest season
--Regular sql expression
SELECT TOP 1 Season, Period FROM [SA45Team12AD].[dbo].[ActualData]
WHERE Season IN (SELECT TOP 1 Season FROM [SA45Team12AD].[dbo].[ActualData] WHERE ItemID = 'E032' ORDER BY Season)
AND ItemID = 'E032'
ORDER BY Period
--Using stored procedure
CREATE PROCEDURE Earliest_PnS (@ItemID NVARCHAR(100))
AS BEGIN
	SELECT TOP 1 Season, Period FROM [SA45Team12AD].[dbo].[ActualData]
	WHERE Season IN (SELECT TOP 1 Season FROM [SA45Team12AD].[dbo].[ActualData] WHERE ItemID = @ItemID ORDER BY Season)
	AND ItemID = @ItemID
	ORDER BY Period
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[Earliest_PnS] @ItemID = 'F032'
	--To drop this sp,
	DROP PROCEDURE Earliest_PnS






--6. Finding the latest period from the latest season
--Regular sql expression
SELECT TOP 1 Season, Period FROM [SA45Team12AD].[dbo].[ActualData]
WHERE Season IN (SELECT TOP 1 Season FROM [SA45Team12AD].[dbo].[ActualData] WHERE ItemID = 'E032' ORDER BY Season DESC)
AND ItemID = 'E032'
ORDER BY Period Desc
--Using stored procedure
CREATE PROCEDURE Latest_PnS (@ItemID NVARCHAR(100))
AS BEGIN
	SELECT TOP 1 Season, Period FROM [SA45Team12AD].[dbo].[ActualData]
	WHERE Season IN (SELECT TOP 1 Season FROM [SA45Team12AD].[dbo].[ActualData] WHERE ItemID = @ItemID ORDER BY Season DESC)
	AND ItemID = @ItemID
	ORDER BY Period Desc
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[Latest_PnS] @ItemID = 'F032'
	--To drop this sp,
	DROP PROCEDURE Latest_PnS





--7. Finding the latest period from the latest season
--Regular sql expression
SELECT TOP 1 * FROM [SA45Team12AD].[dbo].[ActualData]
ORDER BY Season Desc, Period Desc
--Using stored procedure
CREATE PROCEDURE LatestActualDataEntry
AS BEGIN
	SELECT TOP 1 * FROM [SA45Team12AD].[dbo].[ActualData]
	ORDER BY Season Desc, Period Desc
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[LatestActualDataEntry]
	--To drop this sp,
	DROP PROCEDURE LatestActualDataEntry




	
	
	
	
	

				-- FORECASTED DATA TABLE --	

SELECT * FROM [SA45Team12AD].[dbo].[ForecastedData]



--8. Creating new entry in the ForecastedData table
INSERT INTO [SA45Team12AD].[dbo].[ForecastedData] (ItemID, Period, Season, ForecastedDemand, Low80, High80, Low95, High95) VALUES ('E032', 2008, 5, 545, 5454, 54, 54, 54)
--Using stored procedure
CREATE PROCEDURE Insert_Forecast (@ItemID NVARCHAR(100), @varSeason INTEGER, @varPeriod INTEGER, @varDd INTEGER, @varLo80 INTEGER, @varHi80 INTEGER, @varLo95 INTEGER, @varHi95 INTEGER)
AS BEGIN
	IF NOT EXISTS (SELECT * FROM [SA45Team12AD].[dbo].[ForecastedData] 
                   WHERE ItemID = @ItemID
				   AND Season = @varSeason
                   AND Period = @varPeriod)
	BEGIN
		INSERT INTO [SA45Team12AD].[dbo].[ForecastedData] (ItemID, Season, Period, ForecastedDemand, Low80, High80, Low95, High95)
		VALUES (@ItemID, @varSeason, @varPeriod, @varDd, @varLo80, @varHi80, @varLo95, @varHi95)
	END
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[Insert_Forecast] @ItemID='F032', @varSeason=2010, @varPeriod=21, @varDd=478, @varLo80=450, @varHi80=500, @varLo95=460, @varHi95=510
	--To drop this sp,
	DROP PROCEDURE Insert_Forecast
	--To delete row,
	DELETE [SA45Team12AD].[dbo].[ForecastedData] WHERE FID > 0
	--Useful for resetting auto increment etc [BUT IT WILL DELETE ALL DATA]
	TRUNCATE TABLE [SA45Team12AD].[dbo].[ForecastedData]





--Checking if all 119 items are captured
SELECT ItemID FROM ForecastedData GROUP BY ItemID





--9. Retrieving the latest 5 entries from the forecast table
--Regular sql expression
SELECT TOP 5 *
FROM [SA45Team12AD].[dbo].[ForecastedData] 
WHERE ItemID = 'C006' 
ORDER BY Season DESC, Period DESC
--Using stored procedure
CREATE PROCEDURE RetrieveLatestForecastData (@ItemID NVARCHAR(100))
AS BEGIN
	SELECT TOP 5 *
	FROM [SA45Team12AD].[dbo].[ForecastedData] 
	WHERE ItemID = @ItemID
	ORDER BY Season DESC, Period DESC
END
	--To call,
	EXEC [SA45Team12AD].[dbo].[RetrieveLatestForecastData] @ItemID = 'C006'
	--To drop this sp,
	DROP PROCEDURE RetrieveLatestForecastData



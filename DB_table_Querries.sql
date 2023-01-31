

-- db name : falcons 


-- timesheet logs table this will calculate 2 columns net hours based on the user input data to start date and end date
create table Timesheetlogs(
timesheet_id INT PRIMARY KEY,
Emp_id int,
Date date,
Description nvarchar(300),
Task_ID int,
start_time TIME,
end_time TIME,
break_time TIME,
total_hours_time AS CONVERT(VARCHAR(8),DATEADD(second, DATEDIFF(second, 0, CAST(DATEADD(hour, DATEDIFF(hour, start_time, end_time), 0) AS TIME)), 0), 108),
 net_hours_time AS CONVERT(VARCHAR(8),DATEADD(second, DATEDIFF(second, 0, CAST(DATEADD(hour, DATEDIFF(hour, start_time, end_time) - DATEDIFF(hour, 0, break_time), 0) AS TIME)), 0), 108)
)


    
CREATE TABLE Customer (
        CUSId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
        ,CUSKey AS 'Cus' + RIGHT('000' + CONVERT(VARCHAR(5), CUSId), 6) PERSISTED
        ,CusName VARCHAR(50)
        ,mobileno INT
        ,Gender VARCHAR(10)
        )


-- employee deatails

CREATE TABLE EmployeeDetails(
	[Emp_id] [int] IDENTITY(1,1) NOT NULL,
	[EmpFist_Name] [nvarchar](300) NULL,
	[EmpLast_Namec] [nvarchar](300) NULL,
	[Auth_role] [nvarchar](200) NULL,
	[comapny_role] [nvarchar](200) NULL,
	[Contract_type] [nvarchar](200) NULL,
	[Note] [nvarchar](500) NULL,
	[Joined_Date] [date] NULL,
	[SkypeId] [nvarchar](300) NULL,
	[Whatsapp] [nvarchar](150) NULL,
	[Company_Email] [nvarchar](200) NULL,
	[Personal_Email] [nvarchar](200) NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](200) NOT NULL)

--LeaveManagementAvailability table creating

CREATE TABLE [dbo].[LeaveManagementAvailability](
	[leaveAvailable_ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpFist_Name] [nvarchar](300) NULL,
	[Emp_id] [int] NULL,
	[leaveTaken_dates] [int] NULL,
	[Anual_leaves] [int] NULL,
	[Sick_leaves] [int] NULL,
	[Study_leaves] [int] NULL,

)



drop table [LeaveManagementAvailability]
INSERT INTO LeaveManagementAvailability (EmpFist_Name, Emp_id, leaveTaken_dates, Anual_leaves, Sick_leaves, Study_leaves)
VALUES ('pasi', 12, 10, 20, 8, 7);


select * from LeaveManagementAvailability

ALTER TABLE LeaveManagementAvailability
ADD Available_dates AS (Anual_leaves + Sick_leaves + Study_leaves);


---task table crete qureey
CREATE TABLE [dbo].[Tasks](
	[Task_ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](300) NULL,
	[Task_description] [nvarchar](300) NULL,
	[Emp_id] [int] NULL,
	[Assigned_to] [nvarchar](300) NULL,
	[Status_id] [int] NULL,
	[Developer_notes] [nvarchar](300) NULL

)


--
CREATE TABLE Company_role(
	[CompanyRole_id] [int] IDENTITY(1,1) NOT NULL,
	[C_Role] [nvarchar](100) NULL
	)

CREATE TABLE Contract_type(
	[Contract_id] [int] IDENTITY(1,1) NOT NULL,
	[Contract] [nvarchar](100) NULL)

CREATE TABLE [dbo].[Status](
	[Status_id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](200) NULL)
	
CREATE TABLE [dbo].[Project](
	[projectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Customer] [nvarchar](200) NULL,
	[AssignTo] [nvarchar](200) NULL,
	[Assigned_Date] [date] NULL,
	[Due_Date] [date] NULL,
	[Comments] [nvarchar](1000) NULL,
	[Status] [nvarchar](100) NULL,
	[Tasks] [nvarchar](500) NULL,
	[Task_ID] [int] NULL
)
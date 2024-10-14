CREATE DATABASE CrimeIncidentDBps;
USE CrimeIncidentDBps;

-- Create the Victims Table
CREATE TABLE Victims (
    VictimID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    ContactInformation VARCHAR(255)
);

-- Create the Suspects Table
CREATE TABLE Suspects (
    SuspectID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    Gender VARCHAR(10),
    ContactInformation VARCHAR(255)
);
-- Create the Incidents Table
CREATE TABLE Incidents (
    IncidentID INT PRIMARY KEY,
    IncidentType VARCHAR(50),
    IncidentDate DATE,
    Location GEOGRAPHY,
    Description VARCHAR(255),
    Status VARCHAR(50),
    VictimID INT,
    SuspectID INT,
    FOREIGN KEY (VictimID) REFERENCES Victims(VictimID),
    FOREIGN KEY (SuspectID) REFERENCES Suspects(SuspectID)
);



-- Create the Law Enforcement Agencies Table
CREATE TABLE LawEnforcementAgencies (
    AgencyID INT PRIMARY KEY,
    AgencyName VARCHAR(100),
    Jurisdiction VARCHAR(100),
    ContactInformation VARCHAR(255)
);

-- Create the Officers Table
CREATE TABLE Officers (
    OfficerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    BadgeNumber VARCHAR(20),
    Rank VARCHAR(50),
    ContactInformation VARCHAR(255),
    AgencyID INT,
    FOREIGN KEY (AgencyID) REFERENCES LawEnforcementAgencies(AgencyID)
);

-- Create the Evidence Table
CREATE TABLE Evidence (
    EvidenceID INT PRIMARY KEY,
    Description VARCHAR(255),
    LocationFound VARCHAR(100),
    IncidentID INT,
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID)
);

-- Create the Reports Table
CREATE TABLE Reports (
    ReportID INT PRIMARY KEY,
    IncidentID INT,
    ReportingOfficer INT,
    ReportDate DATE,
    ReportDetails TEXT,
    Status VARCHAR(50),
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID),
    FOREIGN KEY (ReportingOfficer) REFERENCES Officers(OfficerID)
);


-- Insert data into Victims table
INSERT INTO Victims (VictimID, FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES 
(1, 'Ravi', 'Sharma', '1985-04-22', 'Male', 'Bangalore, Karnataka, 560001, +91 9876543210'),
(2, 'Priya', 'Patel', '1990-07-19', 'Female', 'Mumbai, Maharashtra, 400001, +91 8765432109');

-- Insert data into Suspects table
INSERT INTO Suspects (SuspectID, FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES 
(1, 'Ajay', 'Singh', '1983-11-15', 'Male', 'Chennai, Tamil Nadu, 600001, +91 9988776655'),
(2, 'Sunil', 'Verma', '1989-03-25', 'Male', 'Hyderabad, Telangana, 500001, +91 8877665544');

-- Insert data into Law Enforcement Agencies table
INSERT INTO LawEnforcementAgencies (AgencyID, AgencyName, Jurisdiction, ContactInformation)
VALUES 
(1, 'Bangalore Police Department', 'Bangalore City', 'Bangalore, Karnataka, 560001, +91 9480801000'),
(2, 'Mumbai Police Department', 'Mumbai City', 'Mumbai, Maharashtra, 400001, +91 9876543211');

-- Insert data into Officers table
INSERT INTO Officers (OfficerID, FirstName, LastName, BadgeNumber, Rank, ContactInformation, AgencyID)
VALUES 
(1, 'Amit', 'Kumar', 'BP12345', 'Inspector', 'Bangalore, Karnataka, 560001, +91 9345678901', 1),
(2, 'Neha', 'Reddy', 'MP54321', 'Sub-Inspector', 'Mumbai, Maharashtra, 400001, +91 9123456789', 2);

-- Insert data into Incidents table
INSERT INTO Incidents (IncidentID, IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID)
VALUES 
(1, 'Robbery', '2024-09-15', 'POINT(12.9715987 77.5945627)', 'Robbery at a local store.', 'Closed', 1, 1),
(2, 'Homicide', '2024-10-01', 'POINT(19.076090 72.877426)', 'Homicide in a residential area.', 'Under Investigation', 2, 2);

-- Insert data into Evidence table
INSERT INTO Evidence (EvidenceID, Description, LocationFound, IncidentID)
VALUES 
(1, 'Stolen Watch', 'Store Counter', 1),
(2, 'Knife with Blood Stains', 'Crime Scene', 2);

-- Insert data into Reports table
INSERT INTO Reports (ReportID, IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status)
VALUES 
(1, 1, 1, '2024-09-16', 'Robbery incident investigated and closed. Stolen watch recovered.', 'Finalized'),
(2, 2, 2, '2024-10-02', 'Initial investigation ongoing. Suspect identified.', 'Draft');

-- Print all data from Incidents
SELECT * FROM Incidents;

-- Print all data from Victims
SELECT * FROM Victims;

-- Print all data from Suspects
SELECT * FROM Suspects;

-- Print all data from Law Enforcement Agencies
SELECT * FROM LawEnforcementAgencies;

-- Print all data from Officers
SELECT * FROM Officers;

-- Print all data from Evidence
SELECT * FROM Evidence;

-- Print all data from Reports
SELECT * FROM Reports;

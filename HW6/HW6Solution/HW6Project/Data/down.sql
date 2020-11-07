
/*******************************************************************************
   Chinook Database - Version 1.4
   Script: Chinook_Sqlite_AutoIncrementPKs.sql
   Description: Creates and populates the Chinook database.
   DB Server: Sqlite
   Author: Luis Rocha
   License: http://www.codeplex.com/ChinookDatabase/license
********************************************************************************/

/*******************************************************************************
   Drop Foreign Keys Constraints
********************************************************************************/























/*******************************************************************************
   Drop Tables
********************************************************************************/
DROP TABLE IF EXISTS [Album];

DROP TABLE IF EXISTS [Artist];

DROP TABLE IF EXISTS [Customer];

DROP TABLE IF EXISTS [Employee];

DROP TABLE IF EXISTS [Genre];

DROP TABLE IF EXISTS [Invoice];

DROP TABLE IF EXISTS [InvoiceLine];

DROP TABLE IF EXISTS [MediaType];

DROP TABLE IF EXISTS [Playlist];

DROP TABLE IF EXISTS [PlaylistTrack];

DROP TABLE IF EXISTS [Track];
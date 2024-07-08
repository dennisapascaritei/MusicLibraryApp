-- Create the MusicDB database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MusicDB')
BEGIN
    CREATE DATABASE MusicDB;
END
GO

-- Use the MusicDB database
USE MusicDB;
GO

-- Create Artist table
CREATE TABLE Artists (
    ArtistId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name VARCHAR(255) NOT NULL
);
GO

-- Create Album table
CREATE TABLE Albums (
    AlbumId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Title VARCHAR(255) NOT NULL,
	Description VARCHAR(255) NOT NULL,
    ArtistId UNIQUEIDENTIFIER,
    FOREIGN KEY (ArtistId) REFERENCES Artist(ArtistId)
);
GO

-- Create Song table
CREATE TABLE Songs (
    SongId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Title VARCHAR(255) NOT NULL,
    Length TIME,
    AlbumId UNIQUEIDENTIFIER,
    FOREIGN KEY (AlbumId) REFERENCES Album(AlbumId)
);
GO


EXEC sp_help 'Artists';
EXEC sp_help 'Albums';

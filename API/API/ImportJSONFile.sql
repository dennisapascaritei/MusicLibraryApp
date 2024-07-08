-- Load JSON data from the file into a variable
DECLARE @json NVARCHAR(MAX);

-- Specify the complete file path to your JSON file
SELECT @json = BulkColumn
FROM OPENROWSET (BULK 'D:\Angular\MusicLibraryApp\API\data.json', SINGLE_CLOB) AS j;

-- Validate the JSON format
IF (ISJSON(@json) = 1)
    PRINT 'JSON data is valid';
ELSE
    PRINT 'Error in JSON format';

-- Insert data into Artists table (assuming you have an existing ArtistId for Radiohead)
INSERT INTO Artists (ArtistId, Name)
VALUES (NEWID(), 'Radiohead');

-- Retrieve the ArtistId
DECLARE @ArtistId UNIQUEIDENTIFIER;
SELECT @ArtistId = ArtistId FROM Artists WHERE Name = 'Radiohead';

-- Insert data into Albums table
INSERT INTO Albums (AlbumId, Title, Description, ArtistId)
SELECT NEWID(), a.Title, a.Description, @ArtistId
FROM OPENJSON(@json, '$.albums')
WITH (
    Title NVARCHAR(255),
    Description NVARCHAR(MAX),
    songs NVARCHAR(MAX) AS JSON
) AS a;

-- Retrieve the AlbumId
DECLARE @AlbumId UNIQUEIDENTIFIER;
SELECT @AlbumId = AlbumId FROM Albums WHERE Title = 'The King of Limbs';

-- Insert data into Songs table
INSERT INTO Songs (SongId, Title, Length, AlbumId)
SELECT NEWID(), s.Title, CONVERT(TIME, s.Length), @AlbumId
FROM OPENJSON(a.songs)
WITH (
    Title NVARCHAR(255),
    Length NVARCHAR(5)
) AS s;

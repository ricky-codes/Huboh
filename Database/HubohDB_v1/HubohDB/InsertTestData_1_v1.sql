use HubohDB_v1;

insert into Artists_Albums(albumID, artistID) values
(1, 3),
(2, 2);

insert into Songs(title, trackNumber, songYear, bpm, lyricsID, filepathID) values
('Lose Yourself', 4, 1998, 125, null, 1),
('Do I Wanna Know', 2, 2010, 90, null, 2);

insert into Composers_Songs(composerID, songID) values
(3, 1),
(2, 2);

insert into Artist_Songs(songID, artistID) values
(1, 1),
(2, 3);

insert into Genres_Songs(genreID, songID) values 
(1,2),
(2,1);


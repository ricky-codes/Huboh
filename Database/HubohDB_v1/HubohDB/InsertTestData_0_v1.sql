use HubohDB_v1;

insert into FilePaths(fileFilename, fileDirectory, fileFullpath) values 
('first_file', 'C:\first_folder', 'C:\first_folder\first_file'),
('second_file', 'C:\first_folder', 'C:\first_folder\second_file');

insert into Publishers(publisherName) values
('Sony Music'),
('Warner Music');

insert into Composers(composerName) values
('Ricky'),
('Padre'),
('Costa');

insert into Genres(genreDescription) values
('Rock'),
('Rap'),
('Folk');

insert into Artists(artistName, birthday, albumCount, publisherID) values
('Arctic Monkeys', null, 5, 1),
('Pearl Jam', null, 8, 2),
('Eminem', null, 6, 1);

insert into Albums(albumName, trackCount, releaseYear) values
('8 Mile', 12, 1998),
('AM', 10, 2010);
CREATE PROCEDURE ReseedAll	
AS
BEGIN
	SET NOCOUNT ON;
	EXECUTE sp_MSforeachtable 'DBCC CHECKIDENT (''?'',RESEED, 0)';
END
GO


create procedure InsertGenre(@_genre varchar(50))
as
begin

	if not exists (select * from HubohDB_v1.dbo.Genres
					where genreDescription = @_genre)
		begin
			insert into HubohDB_v1.dbo.Genres(genreDescription)
			values (@_genre)
		end
	else 
		begin
			select genreID from HubohDB_v1.dbo.Genres where genreDescription = @_genre
		end
end
go

create procedure DisableAllConstraints
as
begin
	set nocount on;
	execute sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL';
end
go
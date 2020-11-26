CREATE PROCEDURE ReseedAll	
AS
BEGIN
	SET NOCOUNT ON;
	EXECUTE sp_MSforeachtable 'DBCC CHECKIDENT (''?'',RESEED, 0)';
END
GO


create procedure TruncateAll
as
begin
	set nocount on;
	execute sp_MSforeachtable 'TRUNCATE TABLE ''?'' ';
end
go

create procedure DisableAllConstraints
as
begin
	set nocount on;
	execute sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL';
end
go
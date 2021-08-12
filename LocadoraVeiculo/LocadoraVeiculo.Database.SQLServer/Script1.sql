select * from TBClienteCNPJ
delete from TBClienteCNPJ
DBCC CHECKIDENT ( TBClienteCNPJ, RESEED )


select * from TBClienteCPF
delete from TBClienteCPF
DBCC CHECKIDENT ( TBClienteCPF, RESEED )
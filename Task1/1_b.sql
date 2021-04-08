use ControlWork
go

With s1 as (select count(DentistId) as DentistCount,DentistId,
MONTH(Date) as MONTH 
from Visits
group by DentistId, MONTH(Date)) 
select DentistId,max(DentistCount) as Max from s1 group by DentistId



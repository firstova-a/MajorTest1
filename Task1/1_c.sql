use ControlWork
go

select FIO from Clients
where Id in 
(select ClientDentist.ClientsId from ClientDentist
group by ClientsId
having count(DISTINCT DentistsId)>=2)
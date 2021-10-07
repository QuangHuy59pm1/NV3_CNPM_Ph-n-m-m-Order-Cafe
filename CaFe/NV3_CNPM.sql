create database QLCafe
use QLCafe
drop database QLCafe

create table drink(
MaD int identity primary key not null,
tengoiD nvarchar(50),
Dongia float
)
insert into drink
values (N'Nước Chanh Tươi','25000'),
       (N'Nước cam','25000'),
		(N'Bạc Xỉu','25000'),
		(N'Nước Dừa','25000'),
		(N'Cà Phê Nâu Phin','25000'),
		(N'Cà Phê Đen Phin','25000');
		
		


drop table cftable

create table cftable(
SoBan nvarchar(20) primary key not null,
tinhtrang nvarchar(50) default 'Trống'
)


declare @i int =1
while(@i<=13)
begin
	insert into cftable
	values ('Bàn '+cast(@i as nvarchar(50)),'trống');
	set @i = @i +1;
	
end

drop table bills

create table bills(
MaHD int ,
SoBan nvarchar(20) not null,
tendo nvarchar(50),
soluong int,
Tongtien float,
thanhtien float,
foreign key(MaHD) references oderlist(MaDS),
foreign key(SoBan) references cftable(SoBan),

)


drop table oderlist

create table oderlist(
MaDS int identity primary key not null,
SoBan nvarchar(20),
MaD int,
tendo nvarchar(50),
Dongia float,
Note nvarchar(500),
foreign key(MaD) references drink(MaD),
foreign key(SoBan) references cftable(SoBan)
)

insert into oderlist(SoBan, tendo, note)
values (N'Bàn 7', N'Bạc Xỉu', N'Giảm đường, làm ấm')

select * from drink
select * from bills
select *from oderlist 
select * from cftable

drop trigger MaD
create trigger MaD
on oderlist for insert
as 
	update oderlist
	set MaD = (select MaD from drink where oderlist.tendo = drink.tengoiD)
	update oderlist
	set Dongia = (select Dongia from drink where oderlist.tendo = drink.tengoiD) 
	insert into bills
	(MaHD,SoBan,tendo)
	select MaDS, SoBan, tendo from oderlist
	/*select SoBan, drink.MaD,inserted.tendo, drink.Dongia, note from drink, inserted
	where (select tendo from oderlist) = tengoiD;
	--delete from oderlist
	--where SoBan = 'Bàn 5';*/


drop proc back
alter proc back
as
begin
update oderlist
set MaD = (select MaD from drink where oderlist.tendo = drink.tengoiD)
update oderlist
set Dongia = (select Dongia from drink where oderlist.tendo = drink.tengoiD)
end

drop proc SL
create proc SL
as begin
update bills
set soluong = (select  count(oderlist.tendo) from oderlist
where bills.MaHD = oderlist.MaDS and bills.tendo = oderlist.tendo)
end

create proc ThanhTien
as begin
update bills
set thanhtien = soluong*Dongia from bills, oderlist
where bills.MaHD = oderlist.MaDS and bills.tendo = oderlist.tendo
end


create proc TongTien
as begin
update bills
set Tongtien = (select sum(thanhtien) from bills, oderlist
where bills.MaHD = oderlist.MaDS)
end

update bills
set thanhtien = dongia*soluong
	
update bills
set	soluong = count(tendo)
where bills.tendo = (select tendo from oderlist) and MaHD = (select MaDS from oderlist)

alter proc dem(@a nvarchar(50))
as 
begin
	select soluong = count(bills.tendo)  
	from bills,oderlist
	where bills.id = oderlist.idtable and bills.tendo = @a
end


exec dem('')

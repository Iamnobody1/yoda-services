<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD:sql/yoda.sql
CREATE TABLE public."Users" (
	"Id" varchar(36) NOT NULL,
	"Username" varchar(256) NULL,
	"Password" varchar(12) NULL,
	"DisplayName" varchar(10) NULL,
	"Avatar" varchar(256) NULL,
	CONSTRAINT "Users_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Customer" (
	"Id" int NULL,
	"Name" varchar(32) NULL,
	CONSTRAINT "Customer_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Product" (
	"Id" int NULL,
	"Name" varchar(32) NULL,
	CONSTRAINT "Product_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Order" (
	"Id" int NULL,
	"CustomerId" int NULL,
	"CreateDateUTC" timestamptz NULL,
	CONSTRAINT "Order_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."OrderDetail" (
	"Id" int NULL,
	"OrderId" int NULL,
	"ProductId" int NULL,
	"Quantity" int NULL,
	"UnitPrice" money NULL,
	CONSTRAINT "PK_OrderDetail_Id" PRIMARY KEY ("Id")
);

ALTER TABLE public."OrderDetail" CONSTRAINT "Order_Customer_FK" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("Id") ON DELETE CASCADE ON UPDATE cascade;

ALTER TABLE public."OrderDetail" CONSTRAINT "FK_OrderDetail_Order" FOREIGN KEY ("OrderId") REFERENCES "Order" ("Id") ON DELETE CASCADE ON UPDATE cascade;

ALTER TABLE public."OrderDetail" CONSTRAINT "FK_OrderDetail_Product" FOREIGN KEY ("ProductId") REFERENCES "Product" ("Id") ON DELETE CASCADE ON UPDATE cascade;

insert INTO public."Customer" ("Id", "Name")
values (1 ,'John Smith');

insert INTO public."Product" ("Id", "Name")
values (1, 'Oculus Rift');

insert INTO public."Order" ("Id", "CustomerId", "CreateDateUTC")
values (1, 1, '2016-01-01 10:00:00');

insert INTO public."OrderDetail" ("Id", "OrderId", "ProductId", "Quantity" ,"UnitPrice")
values (1, 1, 4, 1, 14000);
=======
CREATE TABLE public."Users" (
	"Id" varchar(36) NOT NULL,
	"Username" varchar(256) NULL,
	"Password" varchar(12) NULL,
	"DisplayName" varchar(10) NULL,
	"Avatar" varchar(256) NULL,
	CONSTRAINT "Users_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Customer" (
	"Id" int NULL,
	"Name" varchar(32) NULL,
	CONSTRAINT "Customer_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Product" (
	"Id" int NULL,
	"Name" varchar(32) NULL,
	CONSTRAINT "Product_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Order" (
	"Id" int NULL,
	"CustomerId" int NULL,
	"CreateDateUTC" timestamptz NULL,
	CONSTRAINT "Order_Id_PK" PRIMARY KEY ("Id"),
	CONSTRAINT "Order_Customer_FK" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE public."OrderDetail" (
	"Id" int NULL,
	"OrderId" int NULL,
	"ProductId" int NULL,
	"Quantity" int NULL,
	"UnitPrice" money NULL,
	CONSTRAINT "OrderDetail_Id_PK" PRIMARY KEY ("Id"),
	CONSTRAINT "OrderDetail_Order_FK" FOREIGN KEY ("OrderId") REFERENCES "Order" ("Id") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT "OrderDetail_Product_FK" FOREIGN KEY ("ProductId") REFERENCES "Product" ("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

ALTER TABLE public."OrderDetail"
    ADD CONSTRAINT fk_orders_customers FOREIGN KEY (customer_id) REFERENCES customers (id);

insert INTO public."Customer" ("Id", "Name")
values (1 ,'John Smith');

insert INTO public."Product" ("Id", "Name")
values (1, 'Oculus Rift');

insert INTO public."Order" ("Id", "CustomerId", "CreateDateUTC")
values (1, 1, '2016-01-01 10:00:00');

insert INTO public."OrderDetail" ("Id", "OrderId", "ProductId", "Quantity" ,"UnitPrice")
values (1, 1, 4, 1, 14000);
=======
CREATE TABLE public."Users" (
	"ID" varchar(36) NOT NULL,
	"Username" varchar(256) NULL,
	"Password" varchar(12) NULL,
	"DisplayName" varchar(10) NULL,
	"Avatar" varchar(256) NULL,
	CONSTRAINT "Users_ID_PK" PRIMARY KEY ("ID")
);
>>>>>>> demo/best2
=======
CREATE TABLE public."Users" (
    "ID" int NOT NULL,
    "Username" varchar(256) NULL,
    "Password" varchar(12) NULL,
    "DisplayName" varchar(10) NULL,
    "Avatar" varchar(256) NULL,
    CONSTRAINT "Users_ID_PK" PRIMARY KEY ("ID")
);
>>>>>>> 0d0f294761979887937f334dcdcd0c61b8c903b3:sql/customer.sql


ALTER TABLE public."Orders" ADD CONSTRAINT "Orders_CustomerId_FK" FOREIGN KEY ("CustomerId") REFERENCES public."Customers"("Id") ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE public."Order" RENAME TO "Orders";

SELECT "CreateDateUTC", "CreateDateUTC"::Date, cast("CreateDateUTC" as date), "CreateDateUTC"::varchar  
FROM public."Order";

select odr."Id",cus."Name", odr."CreateDateUTC" 
from "Customer"             cus
inner join "Order"             odr on odr."CustomerId" = cus."Id"
where odr."CreateDateUTC"::varchar = '2016-01-01 10:00:00+07'
--where odr."CreateDateUTC"::date::varchar = '2016-01-01'
order by cus."Name", "CreateDateUTC"
;

select odr."Id",cus."Name", odr."CreateDateUTC" 
from "Customer"             cus
inner join "Order"             odr on odr."CustomerId" = cus."Id"
where odr."CreateDateUTC" (CreateDat(yy, YourDateColumn) = 1996 
order by cus."Name", "CreateDateUTC"
;
where (DATEPART(yy, YourDateColumn) = 1996 AND DATEPART(mm, YourDateColumn) = 4 AND DATEPART(dd, YourDateColumn) = 4)

select distinct cus."Name" 
from "Customer"             cus
inner join "Order"             odr on odr."CustomerId" = cus."Id"
inner join "OrderDetail"    odt on odt."OrderId" = odr."Id"
inner join "Product"        pro on pro."Id" = odt."ProductId"
where pro."Name" = 'Macbook Pro'
order by cus."Name"
;

select cus."Name" , sum(odt."UnitPrice") 
from "Customer"             cus
inner join "Order"             odr on odr."CustomerId" = cus."Id"
inner join "OrderDetail"    odt on odt."OrderId" = odr."Id"
inner join "Product"        pro on pro."Id" = odt."ProductId"
where cus."Name" = 'Best'
group by cus."Name", odr."Id"
;

select cus."Name" , pro."Name" , odt."Quantity" 
from "Customer" cus
inner join "Order" odr on odr."CustomerId" = cus ."Id" 
inner join "OrderDetail" odt on odt. "OrderId" = odr."Id" 
inner join  "Product" pro on pro."Id" = odt."ProductId" 

;


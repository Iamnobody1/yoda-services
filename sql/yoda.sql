CREATE TABLE public."Users" (
    "ID" int NOT NULL,
    "Username" varchar(256) NULL,
    "Password" varchar(12) NULL,
    "DisplayName" varchar(10) NULL,
    "Avatar" varchar(256) NULL,
    CONSTRAINT "Users_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."Customer" (
    "ID" int NOT NULL,
    "Name" varchar(256) null,
    CONSTRAINT "Customer_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."Product" (
    "ID" int NOT NULL,
    "Name" varchar(256) null,
    CONSTRAINT "Product_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."Order" (
    "ID" int NOT NULL,
    "CustomerId" int NULL,
    "CreateDateUTC" timestamptz null,
    CONSTRAINT "Order_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."OrderDetail" (
    "ID" int NOT NULL,
    "OrderId" int NULL,
    "ProductId" int NULL,
    "Quantity" int NULL,
    "UnitPrice" money null,
    CONSTRAINT "OrderDetail_ID_PK" PRIMARY KEY ("ID")
);

ALTER TABLE public."Orders" ADD CONSTRAINT "Orders_CustomerId_FK" FOREIGN KEY ("CustomerId") REFERENCES public."Customers"("Id") ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE public."Order" RENAME TO "Orders";

CREATE TABLE public."Users" (
    "ID" varchar(36) NOT NULL,
    "Username" varchar(256) NULL,
    "Password" varchar(12) NULL,
    "DisplayName" varchar(10) NULL,
    "Avatar" varchar(256) NULL,
    CONSTRAINT "Users_ID_PK" PRIMARY KEY ("ID")
);

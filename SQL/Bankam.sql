USE [Bankam]
GO
/****** Object:  Table [dbo].[Table_Hesap]    Script Date: 10.06.2023 04:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Hesap](
	[HesapNo] [bigint] IDENTITY(4000,10) NOT NULL,
	[KullanıcıSifre] [smallint] NULL,
	[Kullanıcıİsim] [varchar](20) NULL,
	[KullanıcıSoyad] [varchar](20) NULL,
	[KullanıcıCinsiyet] [varchar](5) NULL,
	[KullanıcıTelefon] [char](11) NULL,
	[KullanıcıTC] [char](12) NULL,
	[KullanıcıBakiye] [bigint] NULL,
	[ToplamHavale] [smallint] NULL,
	[ToplamGelenPara] [int] NULL,
	[ToplamGidenPara] [int] NULL,
 CONSTRAINT [PK_Table_Hesap_1] PRIMARY KEY CLUSTERED 
(
	[HesapNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Table_Hesap] ON 

INSERT [dbo].[Table_Hesap] ([HesapNo], [KullanıcıSifre], [Kullanıcıİsim], [KullanıcıSoyad], [KullanıcıCinsiyet], [KullanıcıTelefon], [KullanıcıTC], [KullanıcıBakiye], [ToplamHavale], [ToplamGelenPara], [ToplamGidenPara]) VALUES (4000, 123, N'ALP', N'Mert', N'Erkek', N'555555     ', N'1111        ', 269, 169, 218, 607)
INSERT [dbo].[Table_Hesap] ([HesapNo], [KullanıcıSifre], [Kullanıcıİsim], [KullanıcıSoyad], [KullanıcıCinsiyet], [KullanıcıTelefon], [KullanıcıTC], [KullanıcıBakiye], [ToplamHavale], [ToplamGelenPara], [ToplamGidenPara]) VALUES (4010, 123, N'a', NULL, NULL, NULL, NULL, 0, 25, 1, 815)
SET IDENTITY_INSERT [dbo].[Table_Hesap] OFF
GO
ALTER TABLE [dbo].[Table_Hesap] ADD  CONSTRAINT [DF_Table_Hesap_KullanıcıBakiye]  DEFAULT ((0)) FOR [KullanıcıBakiye]
GO
ALTER TABLE [dbo].[Table_Hesap] ADD  CONSTRAINT [DF_Table_Hesap_ToplamHavale]  DEFAULT ((0)) FOR [ToplamHavale]
GO
ALTER TABLE [dbo].[Table_Hesap] ADD  CONSTRAINT [DF_Table_Hesap_ToplamGelenPara]  DEFAULT ((0)) FOR [ToplamGelenPara]
GO
ALTER TABLE [dbo].[Table_Hesap] ADD  CONSTRAINT [DF_Table_Hesap_ToplamGidenPara]  DEFAULT ((0)) FOR [ToplamGidenPara]
GO

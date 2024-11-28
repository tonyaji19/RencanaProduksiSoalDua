USE [ProductionPlanCar]
GO

/****** Object:  Table [dbo].[ProductionPlan]    Script Date: 28/11/2024 12:13:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductionPlan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Monday] [int] NOT NULL,
	[Tuesday] [int] NOT NULL,
	[Wednesday] [int] NOT NULL,
	[Thursday] [int] NOT NULL,
	[Friday] [int] NOT NULL,
	[Saturday] [int] NOT NULL,
	[Sunday] [int] NOT NULL,
	[AdjustedMonday] [int] NULL,
	[AdjustedTuesday] [int] NULL,
	[AdjustedWednesday] [int] NULL,
	[AdjustedThursday] [int] NULL,
	[AdjustedFriday] [int] NULL,
	[AdjustedSaturday] [int] NULL,
	[AdjustedSunday] [int] NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductionPlan] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO



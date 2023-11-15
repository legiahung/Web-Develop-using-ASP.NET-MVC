CREATE DATABASE Thi62CNTT12_62130690
GO
USE Thi62CNTT12_62130690
GO

CREATE TABLE DoiTuong(
	MaDT VARCHAR(10) PRIMARY KEY,
	TenDT NVARCHAR(50) NOT NULL,
)

CREATE TABLE HocVien(
	MaHV VARCHAR(10) PRIMARY KEY,
	HoSV NVARCHAR(50) NOT NULL,
	TenSV NVARCHAR(50) NOT NULL,
	Anh NVARCHAR(100),
	NgaySinh DATE,
	GioiTinh BIT NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	MaDT VARCHAR(10) NOT NULL FOREIGN KEY REFERENCES dbo.DoiTuong(MaDT)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)

INSERT INTO dbo.DoiTuong VALUES ('HS', N'Học Sinh')
INSERT INTO dbo.DoiTuong VALUES ('SV',N'Sinh Viên')
INSERT INTO dbo.DoiTuong VALUES ('KT',N'Khám Thính')

INSERT INTO dbo.HocVien VALUES('62130690',N'Lê', N'Gia Hưng',N'employee.png','03/06/2002', 1, N'hung.lg,62cntt@ntu.edu.vn',N'Khánh Hòa','SV')
INSERT INTO dbo.HocVien VALUES('63132029',N'Phạm',N'Lê Gia Phúc',N'employee.png','12/29/2002', 1, N'phuc123@gmail.com',N'Cam Ranh','SV')
INSERT INTO dbo.HocVien VALUES('62131224',N'Mai',N'Gia Hân',N'employee.png','12/24/2002', 0, N'han@gmail.com',N'Khánh Hòa','KT')
INSERT INTO dbo.HocVien VALUES('64131224',N'Nguyễn',N'Phạm Mao',N'employee.png','5/2/2004', 0, N'mao@gmail.com',N'Khánh Hòa','HS')

select * from HocVien

CREATE PROCEDURE HocVien_TimKiem
	@HoTen nvarchar(40)=NULL,
	@MaDT nvarchar(10)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM HocVien
       WHERE  (1=1)
       '
IF @HoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (HoSV+'' ''+TenSV LIKE ''%'+@HoTen+'%'')
              '
IF @MaDT IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (MaDT LIKE ''%'+@MaDT+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END

/* Consultar las ultimas consultasen la DDBB */
/*SELECT deqs.last_execution_time AS [Time], dest.text AS [Query]
FROM sys.dm_exec_query_stats AS deqs
CROSS APPLY sys.dm_exec_sql_text(deqs.sql_handle) AS dest
ORDER BY deqs.last_execution_time DESC;*/

/* COLGAAP */

SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO

/* Consultas SQL WO */

IF OBJECT_ID (N'dbo.vw_ca_saldos_cg', N'U') IS NOT NULL  
    DROP TABLE vw_ca_saldos_cg;
GO

CREATE TABLE vw_ca_saldos_cg(
 ano INTEGER, 
 mes INTEGER,
 codigo VARCHAR(20), 
 descripcion TEXT, 
 efecto numeric(28,6),
 saldo_inicial numeric(28,6), 
 debito numeric(28,6), 
 credito numeric(28,6), 
 saldo_final numeric(28,6)
);

/* NIIF */
IF OBJECT_ID (N'dbo.UfnGetSaldoInicialCG', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetSaldoInicialCG;  
GO

IF OBJECT_ID (N'dbo.UfnGetDebitoCG', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetDebitoCG;  
GO  

IF OBJECT_ID (N'dbo.UfnGetCreditoCG', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetCreditoCG;  
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[spEliminarSaldoCuentaPeriodoCG]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
	BEGIN
		DROP PROCEDURE [dbo].[spEliminarSaldoCuentaPeriodoCG]
	END
GO

CREATE PROCEDURE dbo.spEliminarSaldoCuentaPeriodoCG (@Ano INTEGER ) WITH ENCRYPTION
	AS
		BEGIN  
			DELETE FROM vw_ca_saldos_cg WHERE ano >=@Ano;
		END;
GO

CREATE FUNCTION dbo.UfnGetSaldoInicialCG(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
)  
RETURNS numeric(28,6)   WITH ENCRYPTION 
AS   
-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaFinTempSaldoInicial datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@SaldoInicial numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaFinTempSaldoInicial =  DATEADD(DAY,-1, CAST(convert(datetime, @FechaIni, 103) + ' 23:59:59' AS DATETIME))
	--Calculo del saldo inicial
	SELECT @SaldoInicial = COALESCE(Sum(([Débito]-[Crédito])*[Efecto]), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS = 0 AND CCA.[IdCuentaContableDocumento] <> 'CCR' AND 
	CCA.Fecha <= @FechaFinTempSaldoInicial AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @SaldoInicial
END;  
GO


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION dbo.UfnGetDebitoCG(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@FechaFin        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
) RETURNS numeric(28,6)   WITH ENCRYPTION AS   
	-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaIniTemp datetime,
	@FechaFinTemp datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@debito numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaIniTemp = CAST(convert(datetime, @FechaIni, 103) + ' 00:00:00' AS DATETIME)
	set @FechaFinTemp = CAST(convert(datetime, @FechaFin, 103) + ' 23:59:59' AS DATETIME)
	
	--Calculo del Movimiento Debito y credito
	SELECT @Debito = COALESCE(Sum([Débito]), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP 
	INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable 
	INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable 
	INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS = 0 AND CCA.[IdCuentaContableDocumento] <> 'CCR' AND 
	CCA.Fecha Between @FechaIniTemp And @FechaFinTemp AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @Debito
END;  
GO

SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION dbo.UfnGetCreditoCG(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@FechaFin        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
)  
RETURNS numeric(28,6)   WITH ENCRYPTION
AS   
-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaIniTemp datetime,
	@FechaFinTemp datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@credito numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaIniTemp = CAST(convert(datetime, @FechaIni, 103) + ' 00:00:00' AS DATETIME)
	set @FechaFinTemp = CAST(convert(datetime, @FechaFin, 103) + ' 23:59:59' AS DATETIME)
	
	--Calculo del Movimiento Debito y credito
	SELECT @credito = COALESCE(Sum(Crédito), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP 
	INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable 
	INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable 
	INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS = 0 AND  CCA.[IdCuentaContableDocumento] <> 'CCR' AND 
	CCA.Fecha Between @FechaIniTemp And @FechaFinTemp AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @Credito
END;  
GO

/* NIIF */


IF OBJECT_ID (N'dbo.vw_ca_saldos', N'U') IS NOT NULL  
    DROP TABLE vw_ca_saldos;
GO

CREATE TABLE vw_ca_saldos(
 ano INTEGER, 
 mes INTEGER,
 codigo VARCHAR(20), 
 descripcion TEXT, 
 saldo_inicial numeric(28,6), 
 debito numeric(28,6), 
 credito numeric(28,6), 
 saldo_final numeric(28,6)
);

/* NIIF */
IF OBJECT_ID (N'dbo.UfnGetSaldoInicial', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetSaldoInicial;  
GO

IF OBJECT_ID (N'dbo.UfnGetDebito', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetDebito;  
GO  

IF OBJECT_ID (N'dbo.UfnGetCredito', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetCredito;  
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[spEliminarSaldoCuentaPeriodo]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
	BEGIN
		DROP PROCEDURE [dbo].[spEliminarSaldoCuentaPeriodo]
	END
GO

CREATE PROCEDURE dbo.spEliminarSaldoCuentaPeriodo (@Ano INTEGER ) WITH ENCRYPTION
	AS
		BEGIN  
			DELETE FROM vw_ca_saldos WHERE ano >=@Ano;
		END;
GO

CREATE FUNCTION dbo.UfnGetSaldoInicial(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
)  
RETURNS numeric(28,6)   WITH ENCRYPTION 
AS   
-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaFinTempSaldoInicial datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@SaldoInicial numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaFinTempSaldoInicial =  DATEADD(DAY,-1, CAST(convert(datetime, @FechaIni, 103) + ' 23:59:59' AS DATETIME))
	--Calculo del saldo inicial
	SELECT @SaldoInicial = COALESCE(Sum(([Débito]-[Crédito])*[Efecto]), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS <> -1 AND 
	CCA.Fecha <= @FechaFinTempSaldoInicial AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @SaldoInicial
END;  
GO


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION dbo.UfnGetDebito(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@FechaFin        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
) RETURNS numeric(28,6)   WITH ENCRYPTION AS   
	-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaIniTemp datetime,
	@FechaFinTemp datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@debito numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaIniTemp = CAST(convert(datetime, @FechaIni, 103) + ' 00:00:00' AS DATETIME)
	set @FechaFinTemp = CAST(convert(datetime, @FechaFin, 103) + ' 23:59:59' AS DATETIME)
	
	--Calculo del Movimiento Debito y credito
	SELECT @Debito = COALESCE(Sum([Débito]), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP 
	INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable 
	INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable 
	INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS <> -1 AND 
	CCA.Fecha Between @FechaIniTemp And @FechaFinTemp AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @Debito
END;  
GO

SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION dbo.UfnGetCredito(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@FechaFin        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
)  
RETURNS numeric(28,6)   WITH ENCRYPTION
AS   
-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaIniTemp datetime,
	@FechaFinTemp datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@credito numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaIniTemp = CAST(convert(datetime, @FechaIni, 103) + ' 00:00:00' AS DATETIME)
	set @FechaFinTemp = CAST(convert(datetime, @FechaFin, 103) + ' 23:59:59' AS DATETIME)
	
	--Calculo del Movimiento Debito y credito
	SELECT @credito = COALESCE(Sum(Crédito), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP 
	INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable 
	INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable 
	INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS <> -1 AND 
	CCA.Fecha Between @FechaIniTemp And @FechaFinTemp AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @Credito
END;  
GO

/* COLGAAP */

IF OBJECT_ID (N'dbo.vw_ca_saldos', N'U') IS NOT NULL  
    DROP TABLE vw_ca_saldos_cg;
GO

CREATE TABLE vw_ca_saldos_cg(
 ano INTEGER, 
 mes INTEGER,
 codigo VARCHAR(20), 
 descripcion TEXT, 
 saldo_inicial numeric(28,6), 
 debito numeric(28,6), 
 credito numeric(28,6), 
 saldo_final numeric(28,6)
);

IF OBJECT_ID (N'dbo.UfnGetSaldoInicialCG', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetSaldoInicialCG;  
GO

IF OBJECT_ID (N'dbo.UfnGetDebitoCG', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetDebitoCG;  
GO  

IF OBJECT_ID (N'dbo.UfnGetCreditoCG', N'FN') IS NOT NULL  
    DROP FUNCTION UfnGetCreditoCG;  
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[spEliminarSaldoCuentaPeriodo]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
	BEGIN
		DROP PROCEDURE [dbo].[spEliminarSaldoCuentaPeriodo]
	END
GO

CREATE PROCEDURE dbo.spEliminarSaldoCuentaPeriodoCG (@Ano INTEGER ) WITH ENCRYPTION
	AS
		BEGIN  
			DELETE FROM vw_ca_saldos_cg WHERE ano >=@Ano;
		END;
GO

CREATE FUNCTION dbo.UfnGetSaldoInicialCG(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
)  
RETURNS numeric(28,6)   WITH ENCRYPTION 
AS   
-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaFinTempSaldoInicial datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@SaldoInicial numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaFinTempSaldoInicial =  DATEADD(DAY,-1, CAST(convert(datetime, @FechaIni, 103) + ' 23:59:59' AS DATETIME))
	--Calculo del saldo inicial
	SELECT @SaldoInicial = COALESCE(Sum(([Débito]-[Crédito])*[Efecto]), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS <> -1 AND 
	CCA.Fecha <= @FechaFinTempSaldoInicial AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @SaldoInicial
END;  
GO


GO
SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION dbo.UfnGetDebitoCG(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@FechaFin        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
) RETURNS numeric(28,6)   WITH ENCRYPTION AS   
	-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaIniTemp datetime,
	@FechaFinTemp datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@debito numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaIniTemp = CAST(convert(datetime, @FechaIni, 103) + ' 00:00:00' AS DATETIME)
	set @FechaFinTemp = CAST(convert(datetime, @FechaFin, 103) + ' 23:59:59' AS DATETIME)
	
	--Calculo del Movimiento Debito y credito
	SELECT @Debito = COALESCE(Sum([Débito]), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP 
	INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable 
	INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable 
	INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS <> -1 AND 
	CCA.Fecha Between @FechaIniTemp And @FechaFinTemp AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @Debito
END;  
GO

SET ANSI_NULLS, QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION dbo.UfnGetCreditoCG(
@Cuenta          nvarchar(100)='',
@FechaIni        nvarchar(10) = '',
@FechaFin        nvarchar(10) = '',
@CodTercero    nvarchar(100) = NULL,
@EmpresasIncluir nvarchar(4000) = '',
@IdCentroCosto   int = NULL
)  
RETURNS numeric(28,6)   WITH ENCRYPTION
AS   
-- Returns the stock level for the product.  
BEGIN  
    DECLARE
	@FechaIniTemp datetime,
	@FechaFinTemp datetime,
	@CantAleatoria int,
	@IdTercero int,
	@numRows int,
	@Efecto int,
	@credito numeric(28,6)	
	 
	IF NOT(@CodTercero IS NULL OR @CodTercero ='')
	BEGIN
		SELECT @IdTercero=IdTercero  FROM Terceros WHERE Identificacion = @CodTercero
		set @numRows = @@ROWCOUNT

		IF @numRows = 0 
		BEGIN
			--SELECT 'No Existe Código : ' + @CodTercero as CampoValor
			RETURN 0
		END

		IF @numRows > 1 
		BEGIN
			--SELECT 'Código Duplicado : ' + @CodTercero as CampoValor
			RETURN 0
		END
	END
	--set @CantAleatoria = ROUND(((9999999) * RAND()), 0) * -1
	set @CantAleatoria = 1
	set @FechaIniTemp = CAST(convert(datetime, @FechaIni, 103) + ' 00:00:00' AS DATETIME)
	set @FechaFinTemp = CAST(convert(datetime, @FechaFin, 103) + ' 23:59:59' AS DATETIME)
	
	--Calculo del Movimiento Debito y credito
	SELECT @credito = COALESCE(Sum(Crédito), 0)
	FROM [CuentasContables - Tipos] AS CCA_TIP 
	INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable 
	INNER JOIN [CuentasContables - Asientos] AS CCA INNER JOIN [CuentasContables - Asientos - Detalles] AS CCA_D ON CCA.IdAsientoContable = CCA_D.IdAsientoContable 
	INNER JOIN CuentasContables AS CC ON CCA_D.IdCuentaContable = CC.IdCuentaContable ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos 
	WHERE CCA_D.SenalExcNIIFS <> -1 AND 
	CCA.Fecha Between @FechaIniTemp And @FechaFinTemp AND
	IdEmpresa IN(select number from iter$simple_intlist_to_tbl(@EmpresasIncluir)) AND
	COALESCE(CCA_D.IdClasificación,@CantAleatoria)=COALESCE(@IdCentroCosto,CCA_D.IdClasificación,@CantAleatoria) AND
	CCA_D.IdTercero = COALESCE(@IdTercero,CCA_D.IdTercero) AND
	CC.IdCuentaContable IN(select number from iter$simple_intlist_to_tbl_Cuentas(@Cuenta))

	RETURN @Credito
END;  
GO
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoLend.Data.Resources.Car {
    using System;
    
    
    /// <summary>
    ///   Klasa zasobu wymagająca zdefiniowania typu do wyszukiwania zlokalizowanych ciągów itd.
    /// </summary>
    // Ta klasa została automatycznie wygenerowana za pomocą klasy StronglyTypedResourceBuilder
    // przez narzędzie, takie jak ResGen lub Visual Studio.
    // Aby dodać lub usunąć składową, edytuj plik ResX, a następnie ponownie uruchom narzędzie ResGen
    // z opcją /str lub ponownie utwórz projekt VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Sql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Sql() {
        }
        
        /// <summary>
        /// Zwraca buforowane wystąpienie ResourceManager używane przez tę klasę.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AutoLend.Data.Resources.Car.Sql", typeof(Sql).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Przesłania właściwość CurrentUICulture bieżącego wątku dla wszystkich
        ///   przypadków przeszukiwania zasobów za pomocą tej klasy zasobów wymagającej zdefiniowania typu.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu INSERT INTO [dbo].[Cars] (
        ///    [CreateDate],
        ///    [ModifyDate],
        ///    [ModelId],
        ///    [Year],
        ///    [LicensePlate],
        ///    [IsAvailable],
        ///    [IsActive],
        ///    [Cost]
        ///) 
        ///VALUES (
        ///    GETDATE(),
        ///    NULL,
        ///    @ModelId,
        ///    @Year,
        ///    @LicensePlate,
        ///    @IsAvailable,
        ///    1,
        ///    @Cost
        ///)
        ///SELECT Scope_Identity().
        /// </summary>
        public static string Car_Create {
            get {
                return ResourceManager.GetString("Car_Create", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu UPDATE [CA]
        ///SET 
        ///	[CA].[IsActive] = 0 
        ///FROM 
        ///	[dbo].[Cars] AS [CA]
        ///WHERE 
        ///	[CA].[Id] = @carId 
        ///AND [IsActive] = 1;
        ///
        ///UPDATE [R]
        ///SET
        ///	[R].[StatusId] = 2
        ///FROM
        ///	[dbo].[Rentals] AS [R]
        ///WHERE
        ///	[R].[Id] = @carId
        ///AND [R].[IsActive] = 1.
        /// </summary>
        public static string Car_Delete {
            get {
                return ResourceManager.GetString("Car_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu SELECT 
        ///	[CA].[Id], 
        ///	[B].[BrandName], 
        ///	[M].[ModelName], 
        ///	[CA].[Year], 
        ///	[CA].[LicensePlate], 
        ///	[CA].[IsAvailable]
        ///
        ///FROM [dbo].[Cars]				AS [CA]
        ///	INNER JOIN [dbo].[Models]	AS [M]  ON [CA].[ModelId] = [M].Id
        ///	INNER JOIN [dbo].[Brands]	AS [B]  ON [M].[BrandId] = [B].Id
        ///
        ///WHERE 
        ///		[CA].[IsActive] = 1
        ///	AND	[B].[IsActive] = 1
        ///	AND	[M].[IsActive] = 1;.
        /// </summary>
        public static string Car_GetAll {
            get {
                return ResourceManager.GetString("Car_GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu SELECT 
        ///	[CA].[Id], 
        ///	[B].[BrandName], 
        ///	[M].[ModelName], 
        ///	[CA].[Year], 
        ///	[CA].[LicensePlate], 
        ///	[CA].[IsAvailable],
        ///	[CA].[Cost]
        ///
        ///FROM [dbo].[Cars]				AS [CA] 
        ///	INNER JOIN [dbo].[Models]	AS [M]  ON [CA].[ModelId] = [M].[Id]
        ///	INNER JOIN [dbo].[Brands]	AS [B]  ON [M].[BrandId] = [B].[Id]
        ///
        ///WHERE 
        ///		[CA].[Id] = @carId 
        ///	AND [CA].[IsActive] = 1
        ///	AND [M].[IsActive] = 1;
        ///.
        /// </summary>
        public static string Car_GetById {
            get {
                return ResourceManager.GetString("Car_GetById", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu SELECT
        ///	[CA].[Id],
        ///	[CA].[LicensePlate],
        ///	[CA].[IsAvailable],
        ///	[CA].[Cost]
        ///FROM
        ///	[dbo].[Cars] AS [CA]
        ///WHERE
        ///	[CA].[LicensePlate] = @LicensePlate
        ///AND	[CA].[IsActive] = 1.
        /// </summary>
        public static string Car_GetByLicensePlate {
            get {
                return ResourceManager.GetString("Car_GetByLicensePlate", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu SELECT CASE
        ///	WHEN EXISTS(
        ///	SELECT 1 
        ///	FROM 
        ///	[dbo].[Cars] AS [CA] 
        ///	WHERE 
        ///		[CA].[IsActive] = 1
        ///	AND	[CA].[LicensePlate] = @LicensePlate
        ///	AND (@excludeCarId IS NULL OR [CA].[Id] != @excludeCarId)
        ///	)
        ///	THEN 1
        ///	ELSE 0
        ///END
        ///.
        /// </summary>
        public static string Car_LicensePlateExistsAsync {
            get {
                return ResourceManager.GetString("Car_LicensePlateExistsAsync", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu SET @Page       = ISNULL(@Page, 1)
        ///SET @PageSize   = ISNULL(@PageSize, 10)
        ///SET @OrderBy    = ISNULL(@OrderBy, &apos;ModelName&apos;) 
        ///
        ///DECLARE @OrderDesc VARCHAR(10) = 
        ///    CASE
        ///        WHEN @OrderDir IS NULL THEN &apos;ASC&apos;
        ///        WHEN @OrderDir &lt;= 0 THEN &apos;DESC&apos;
        ///        ELSE &apos;ASC&apos;
        ///    END;
        ///
        ///DECLARE @ModelData TABLE (
        ///    ModelId INT
        ///);
        ///
        ///INSERT INTO @ModelData (ModelId)
        ///SELECT ModelId
        ///FROM OPENJSON(@ModelIdsJSON)
        ///WITH (
        ///    ModelId INT &apos;$.ModelId&apos;
        ///);
        ///
        ///SELECT 
        ///    [M].[ModelName], 
        ///    [B].[BrandNa [obcięto pozostałą część ciągu]&quot;;.
        /// </summary>
        public static string Car_Search {
            get {
                return ResourceManager.GetString("Car_Search", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu UPDATE CA
        ///	SET 
        ///		[CA].[year]			= COALESCE(NULLIF(@Year, 0), [CA].[year]), 
        ///		[CA].[ModelId]		= COALESCE((SELECT [id] FROM [dbo].[Models] WHERE [Models].[ModelName] LIKE &apos;%&apos; + NULLIF(@ModelName, &apos;&apos;) + &apos;%&apos;), [CA].[ModelId]),
        ///		[CA].[LicensePlate]	= COALESCE(NULLIF(@LicensePlate, &apos;&apos;), [CA].[LicensePlate]),
        ///		[CA].[IsAvailable]	= COALESCE(@IsAvailable, [CA].[IsAvailable]),
        ///		[CA].[Cost]			= COALESCE(NULLIF(@Cost, 0), [CA].Cost),
        ///		[CA].[ModifyDate]	= GETDATE()
        ///	
        ///	FROM [dbo].[Cars]				AS [CA] 
        ///		INNER [obcięto pozostałą część ciągu]&quot;;.
        /// </summary>
        public static string Car_Update {
            get {
                return ResourceManager.GetString("Car_Update", resourceCulture);
            }
        }
    }
}

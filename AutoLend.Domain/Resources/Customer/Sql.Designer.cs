﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoLend.Data.Resources.Customer {
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
    internal class Sql {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Sql() {
        }
        
        /// <summary>
        /// Zwraca buforowane wystąpienie ResourceManager używane przez tę klasę.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AutoLend.Data.Resources.Customer.Sql", typeof(Sql).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu IF EXISTS (SELECT 1 FROM dbo.Customers WHERE Email = @Email)
        ///BEGIN RAISERROR (&apos;Customer already exists in the database.&apos;,16, 1) END
        ///ELSE
        ///
        ///BEGIN
        ///INSERT INTO dbo.Customers 
        ///	(
        ///	[Id],
        ///	[CreateDate],
        ///	[ModifyDate],
        ///	[Firstname], 
        ///	[Lastname], 
        ///	[Email], 
        ///	[Phone], 
        ///	[Address],
        ///	[LicenseNumber],
        ///	[DateOfBirth],
        ///	[isActive]) 
        ///VALUES
        ///	(
        ///	NEWID(),
        ///	GETDATE(),
        ///	NULL,
        ///	@Firstname, 
        ///	@Lastname, 
        ///	@Email, 
        ///	@Phone, 
        ///	@Address,
        ///	@LicenseNumber,
        ///	@DateOfBirth,
        ///	1
        ///	)
        ///END
        ///
        ///.
        /// </summary>
        internal static string Customer_Create {
            get {
                return ResourceManager.GetString("Customer_Create", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu IF 
        ///(EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId)) 
        ///BEGIN RAISERROR (&apos;Customer not found or is not active.&apos;,16, 1) END
        ///ELSE
        ///
        ///UPDATE dbo.Customers
        ///SET isActive = 0 
        ///WHERE id = @customerId 
        ///AND isActive = 1;.
        /// </summary>
        internal static string Customer_Delete {
            get {
                return ResourceManager.GetString("Customer_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu SELECT Id, CreateDate, ModifyDate, FirstName, LastName, Email, LicenseNumber, Phone, DateofBirth, HasActiveRental Address FROM dbo.Customers.
        /// </summary>
        internal static string Customer_GetAll {
            get {
                return ResourceManager.GetString("Customer_GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu IF 
        ///(EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @customerId)) 
        ///BEGIN RAISERROR (&apos;Customer not found or is not active.&apos;,16, 1) END
        ///ELSE
        ///
        ///SELECT DISTINCT * 
        ///FROM dbo.Customers AS customer 
        ///WHERE customer.id = @customerId
        ///.
        /// </summary>
        internal static string Customer_GetById {
            get {
                return ResourceManager.GetString("Customer_GetById", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu IF 
        ///(EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @Id AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Customers WHERE Id = @Id)) 
        ///BEGIN RAISERROR (&apos;Customer not found or is not active.&apos;,16, 1) END
        ///ELSE
        ///
        ///UPDATE Customers
        ///	SET 
        ///	Customers.FirstName = COALESCE(NULLIF(@FirstName, &apos;&apos;), Customers.FirstName),
        ///	Customers.LastName = COALESCE(NULLIF(@LastName, &apos;&apos;), Customers.LastName),
        ///	Customers.LicenseNumber = COALESCE(NULLIF(@LicenseNumber, &apos;&apos;), Customers.LicenseNumber),
        ///	Customers.Phone = COALESC [obcięto pozostałą część ciągu]&quot;;.
        /// </summary>
        internal static string Customer_Update {
            get {
                return ResourceManager.GetString("Customer_Update", resourceCulture);
            }
        }
    }
}

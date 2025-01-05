﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoLend.Data.Resources.Reservation {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AutoLend.Data.Resources.Reservation.Sql", typeof(Sql).Assembly);
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
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu DECLARE @CustomerId CHAR(36) = (SELECT dbo.Customers.Id FROM dbo.Customers WHERE FirstName = @FirstName AND LastName = @LastName AND Email = @Email)
        ///DECLARE @CarId INT = (SELECT Id FROM dbo.Cars WHERE LicensePlate = @LicensePlate)
        ///DECLARE @StatusId  INT = (SELECT Id FROM dbo.ReservationStatus WHERE StatusName = &apos;Confirmed&apos;)
        ///
        ///
        ///IF @CustomerId IS NULL BEGIN RAISERROR (&apos;Customer not found or is not active.&apos;,16, 1) END
        ///If @CarId IS NULL BEGIN RAISERROR (&apos;Car not found or is not active.&apos;,16, 1) END
        ///
        ///INSER [obcięto pozostałą część ciągu]&quot;;.
        /// </summary>
        internal static string Reservation_Create {
            get {
                return ResourceManager.GetString("Reservation_Create", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu IF 
        ///(EXISTS (SELECT 1 FROM dbo.Reservations WHERE Id = @reservationId AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Reservations WHERE Id = @reservationId)) 
        ///BEGIN RAISERROR (&apos;Reservation not found or is not active.&apos;,16, 1) END
        ///ELSE
        ///
        ///UPDATE dbo.Reservation SET isActive = 0 
        ///WHERE id = @reservationId AND isActive = 1;.
        /// </summary>
        internal static string Reservation_Delete {
            get {
                return ResourceManager.GetString("Reservation_Delete", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu SELECT dbo.Reservations.Id, dbo.Reservations.CreateDate, dbo.Reservations.ModifyDate, 
        ///ReservationFrom, ReservationTo, dbo.Reservations.Description, 
        ///StatusName, BrandName, ModelName, LicensePlate, FirstName, LastName, Email 
        ///FROM dbo.Reservations 
        ///INNER JOIN dbo.ReservationStatus ON dbo.Reservations.StatusId = dbo.ReservationStatus.Id
        ///INNER JOIN dbo.Cars ON dbo.Reservations.CarId = dbo.Cars.Id
        ///INNER JOIN dbo.Customers ON dbo.Reservations.CustomerId = dbo.Customers.Id
        ///INNER JOIN dbo.Models ON dbo.Car [obcięto pozostałą część ciągu]&quot;;.
        /// </summary>
        internal static string Reservation_GetAll {
            get {
                return ResourceManager.GetString("Reservation_GetAll", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu IF 
        ///(EXISTS (SELECT 1 FROM dbo.Reservations WHERE Id = @reservationId AND IsActive = 0)) OR (NOT EXISTS (SELECT 1 FROM dbo.Reservations WHERE Id = @reservationId)) 
        ///BEGIN RAISERROR (&apos;Reservation not found or is not active.&apos;,16, 1) END
        ///ELSE
        ///
        ///
        ///SELECT dbo.Reservations.Id, dbo.Reservations.CreateDate, dbo.Reservations.ModifyDate, 
        ///ReservationFrom, ReservationTo, dbo.Reservations.Description, 
        ///StatusName, BrandName, ModelName, LicensePlate, FirstName, LastName, Email 
        ///FROM dbo.Reservations 
        ///INNER JOIN  [obcięto pozostałą część ciągu]&quot;;.
        /// </summary>
        internal static string Reservation_GetById {
            get {
                return ResourceManager.GetString("Reservation_GetById", resourceCulture);
            }
        }
        
        /// <summary>
        /// Wyszukuje zlokalizowany ciąg podobny do ciągu .
        /// </summary>
        internal static string Reservation_Update {
            get {
                return ResourceManager.GetString("Reservation_Update", resourceCulture);
            }
        }
    }
}

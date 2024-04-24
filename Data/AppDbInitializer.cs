using Magazin_Online.Data.Enums;
using Magazin_Online.Data;
using Magazin_Online.Models;

namespace MagazinOnline.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Admini.Any())
                {
                    context.Admini.AddRange(new Admin
                    {
                        Username = "admin",
                        Password = "admin"
                    });
                    context.SaveChanges();
                }

                if (!context.Utilizatori.Any())
                {
                    context.Utilizatori.AddRange(new Utilizator
                    {
                        Nume = "Teis",
                        Prenume = "Raul",
                        Email = "teisraul@yahoo.co.uk",
                        Parola = "parola",
                        Adresa = "Str. Mihai Eminescu, nr. 1",
                        Oras = Orase.Oradea,
                        Telefon = "0723456789",
                        AdminId = 1
                    });
                    context.SaveChanges();
                }

                if (!context.Produse.Any())
                {
                    context.Produse.AddRange(new List<Produs>
                    {
                        new Produs
                        {
                            Denumire = "Laptop",
                            Categorie = CategorieProdus.Electronice_si_electrocasnice,
                            Pret = 3000,
                            NumarBucati = 3,
                            Imagine = "laptop.jpg",
                            Descriere = "Laptop performant",
                            Orase = Orase.Oradea,
                            UtilizatorId = 1
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
using SD_IKYS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SD_IKYS.Data
{
    public static class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Roller
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role
                    {
                        Name = "Admin",
                        Description = "Sistem yöneticisi",
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    },
                    new Role
                    {
                        Name = "Manager",
                        Description = "Yönetici",
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    },
                    new Role
                    {
                        Name = "Employee",
                        Description = "Çalışan",
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    },
                    new Role
                    {
                        Name = "HR",
                        Description = "İnsan Kaynakları",
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            // Kullanıcılar
            if (!context.Users.Any())
            {
                var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");
                var managerRole = context.Roles.FirstOrDefault(r => r.Name == "Manager");
                var employeeRole = context.Roles.FirstOrDefault(r => r.Name == "Employee");

                // Password hasher oluştur
                var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
                var tempUser = new User(); // Geçici user objesi

                var users = new List<User>
                {
                    new User
                    {
                        Username = "admin",
                        Email = "admin@sdikys.com",
                        Password = passwordHasher.HashPassword(tempUser, "123456"),
                        FirstName = "Admin",
                        LastName = "User",
                        PhoneNumber = "5551234567",
                        RoleId = adminRole?.Id,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    },
                    new User
                    {
                        Username = "manager",
                        Email = "manager@sdikys.com",
                        Password = passwordHasher.HashPassword(tempUser, "123456"),
                        FirstName = "Manager",
                        LastName = "User",
                        PhoneNumber = "5551234568",
                        RoleId = managerRole?.Id,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    },
                    new User
                    {
                        Username = "employee",
                        Email = "employee@sdikys.com",
                        Password = passwordHasher.HashPassword(tempUser, "123456"),
                        FirstName = "Employee",
                        LastName = "User",
                        PhoneNumber = "5551234569",
                        RoleId = employeeRole?.Id,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            // Çalışanlar
            if (!context.Employees.Any())
            {
                var adminUser = context.Users.FirstOrDefault(u => u.Username == "admin");
                var managerUser = context.Users.FirstOrDefault(u => u.Username == "manager");
                var employeeUser = context.Users.FirstOrDefault(u => u.Username == "employee");

                var employees = new List<Employee>
                {
                    new Employee
                    {
                        TCKN = "12345678901",
                        FirstName = "Ahmet",
                        LastName = "Yılmaz",
                        MiddleName = "",
                        DateOfBirth = new DateTime(1985, 5, 15),
                        PlaceOfBirth = "İstanbul",
                        PhoneNumber = "5551234567",
                        Email = "ahmet.yilmaz@sdikys.com",
                        Address = "İstanbul, Türkiye",
                        HireDate = new DateTime(2020, 1, 15),
                        Position = "Genel Müdür",
                        Department = "Yönetim",
                        Salary = 15000,
                        UserId = adminUser?.Id,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    },
                    new Employee
                    {
                        TCKN = "12345678902",
                        FirstName = "Ayşe",
                        LastName = "Demir",
                        MiddleName = "",
                        DateOfBirth = new DateTime(1990, 8, 20),
                        PlaceOfBirth = "Ankara",
                        PhoneNumber = "5551234568",
                        Email = "ayse.demir@sdikys.com",
                        Address = "Ankara, Türkiye",
                        HireDate = new DateTime(2021, 3, 1),
                        Position = "Proje Yöneticisi",
                        Department = "IT",
                        Salary = 12000,
                        UserId = managerUser?.Id,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    },
                    new Employee
                    {
                        TCKN = "12345678903",
                        FirstName = "Mehmet",
                        LastName = "Kaya",
                        MiddleName = "",
                        DateOfBirth = new DateTime(1995, 12, 10),
                        PlaceOfBirth = "İzmir",
                        PhoneNumber = "5551234569",
                        Email = "mehmet.kaya@sdikys.com",
                        Address = "İzmir, Türkiye",
                        HireDate = new DateTime(2022, 6, 1),
                        Position = "Yazılım Geliştirici",
                        Department = "IT",
                        Salary = 8000,
                        UserId = employeeUser?.Id,
                        CreatedDate = DateTime.UtcNow,
                        IsActive = true
                    }
                };

                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }
    }
} 
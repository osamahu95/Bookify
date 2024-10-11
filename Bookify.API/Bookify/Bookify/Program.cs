using AutoMapper;
using Bookify.Data.Data;
using Bookify.Data.JwtBearer;
using Bookify.Service.interfaces;
using Bookify.Service.Mapper;
using Bookify.Service.Services;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Navigations;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.NavigationRepo;
using Repository.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bookify Db Context
builder.Services.AddDbContext<BookifyDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookifyDbConnectionString")));

// Identity User Dependency
builder.Services.AddIdentityCore<User>(options => { 
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<BookifyDbContext>();

// AutoMapper Dependency
builder.Services.AddAutoMapper(typeof(Program));

var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


// Jwt Authentication Dependency
var jwtSettings = builder.Configuration.GetSection("JWTSettings");
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securitykey").Value))
    };
});

builder.Services.AddScoped<JwtHandler>();

// Add UnitOfWork
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Add Services to the Container
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookShopService, BookShopService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IStockService, StockService>();
builder.Services.AddTransient<IUserService, UserService>();

// Add Repositories and Navigation Repository
builder.Services.AddTransient(typeof(IGeneric<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IAuthor, AuthorRepository>();
builder.Services.AddTransient<IBook, BookRepository>();
builder.Services.AddTransient<IBookShop, BookShopRepository>();
builder.Services.AddTransient<ICategory, CategoryRepository>();
builder.Services.AddTransient<IStock, StockRepository>();
builder.Services.AddTransient<IUser, UserRepository>();

builder.Services.AddTransient<IAuthorBook, AuthorBookRepository>();
builder.Services.AddTransient<IBookBookShop, BookBookShopRepository>();
builder.Services.AddTransient<IBookCategory, BookCategoryRepository>();
builder.Services.AddTransient<IBookStock, BookStockRepository>();
builder.Services.AddTransient<IUserAuthor, UserAuthorRepository>();
builder.Services.AddTransient<IUserBook, UserBookRepository>();
builder.Services.AddTransient<IUserBookShop, UserBookShopRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// configure the static files path for the images
app.UseFileServer(new FileServerOptions 
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Uploads")),
    RequestPath = "/uploads"
});

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using app.Data.Abstractions;
using app.Data.Entities;
using app.Data.Entities.Enums;
using app.Data.Repositories.Abstractions;
using app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app.Controllers;

public class UserController(
    IUserRepository repository,
    IUnitOfWork unitOfWork) : Controller
{
    public async Task<IActionResult> UserList()
    {
        var users = await repository.ListAsync(CancellationToken.None);

        var userViewModels = new List<UserModel>();
        foreach (var userEntity in users)
        {
            userViewModels.Add(new UserModel
            {
                Id = userEntity.Id,
                IdentificationNumber = userEntity.IdentificationNumber,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email,
                Gender = userEntity.Gender,
                Type = userEntity.Type,
                BirthDate = userEntity.BirthDate
            });
        }

        return View(userViewModels);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var userEntity = await repository.GetById(id, CancellationToken.None);

        if (userEntity == null)
        {
            return NotFound();
        }

        var userModel = new UserModel
        {
            Id = userEntity.Id,
            IdentificationNumber = userEntity.IdentificationNumber,
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            Email = userEntity.Email,
            Gender = userEntity.Gender,
            Type = userEntity.Type,
            BirthDate = userEntity.BirthDate
        };

        return View(userModel);
    }

    public async Task<IActionResult> CreateUser()
    {
        return View("CreateUser");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUser(User user)
    {
        var newUser = new User
        {
            IdentificationNumber = user.IdentificationNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Gender = user.Gender,
            Type = user.Type,
            BirthDate = user.BirthDate,
            Deleted = false,
            CreatedTime = DateTimeOffset.UtcNow
        };

        repository.CreateAsync(newUser);
        await unitOfWork.CommitChangesAsync(CancellationToken.None);

        return RedirectToAction("UserList");
    }


    public async Task<IActionResult> EditUser(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var userEntity = await repository.GetById(id, CancellationToken.None);

        if (userEntity == null)
        {
            return NotFound();
        }

        var model = new EditUserModel
        {
            UserId = userEntity.Id,
            Email = userEntity.Email,
            Type = userEntity.Type,
            UserTypes = Enum.GetValues(typeof(UserType))
                .Cast<UserType>()
                .Select(t => new SelectListItem
                {
                    Value = ((int)t).ToString(),
                    Text = t.ToString()
                })
                .ToList()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(Guid id, EditUserModel model)
    {
        var userEntity = await repository.GetById(id, CancellationToken.None);

        userEntity.Email = model.Email;
        userEntity.Type = model.Type;

        repository.Update(userEntity);

        await unitOfWork.CommitChangesAsync(CancellationToken.None);

        return RedirectToAction("UserList");
    }

    public async Task<IActionResult> DeleteUser(Guid id)
    {
        if (id == Guid.Empty)
        {
            return NotFound();
        }

        var userEntity = await repository.GetById(id, CancellationToken.None);

        if (userEntity == null)
        {
            return NotFound();
        }

        var model = new EditUserModel
        {
            UserId = userEntity.Id,
            Email = userEntity.Email,
            Type = userEntity.Type,
            UserTypes = Enum.GetValues(typeof(UserType))
                .Cast<UserType>()
                .Select(t => new SelectListItem
                {
                    Value = ((int)t).ToString(),
                    Text = t.ToString()
                })
                .ToList()
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUser(Guid id, EditUserModel model)
    {
        var userEntity = await repository.GetById(id, CancellationToken.None);

        userEntity.Deleted = true;

        repository.Update(userEntity);

        await unitOfWork.CommitChangesAsync(CancellationToken.None);

        return RedirectToAction("UserList");
    }
}
document.addEventListener('DOMContentLoaded', function() {
    const addButton = document.getElementById('std_add');
    const addStdListButton = document.getElementById('add_std_list');

    addButton.addEventListener('click', function() {
        showStdModal();
    });

    function showStdModal() {
        const modal = document.querySelector('.body_std_modal');

        if (!modal.classList.contains('active')) {
            modal.classList.add('active');

            document.getElementById('name_std').value = '';
            document.getElementById('mail_std').value = '';
            document.getElementById('password_std').value = '';
        } else {
            modal.classList.remove('active');
            closeModalAndSubmit(); 
        }
    }

    window.onclick = function(event) {
        const modal = document.querySelector('.body_std_modal');

        if (event.target === modal) {
            modal.classList.remove('active');
            closeModalAndSubmit(); 
        }
    };

    addStdListButton.addEventListener('click', function() {
        closeModalAndSubmit();
    });
});
let showErrorAlert = false;
function closeModalAndSubmit() {
    if (document.getElementById('name_std').value && document.getElementById('mail_std').value && document.getElementById('password_std').value) {
        var name = document.getElementById('name_std').value.trim();
        var email = document.getElementById('mail_std').value.trim();
        var password = document.getElementById('password_std').value.trim();

        var user = {
            "name": name,
            "email": email,
            "password": password
        };

        var urlRegister = 'http://192.168.251.224:5050/api/user/register';

        axios.post(urlRegister, user, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
.then(function(response) {
            if (response.status === 200) {
                alert('Пользователь успешно зарегистрирован!');
                location.reload();
            } else if (response.status === 400 || response.status === 401) {
                const errorMessage = response.data;
                if (!showErrorAlert) {
                    alert(errorMessage);
                    showErrorAlert = true;
                }
            }
        })
.catch(function(error) {
            if (!showErrorAlert) {
                alert('Произошла ошибка: ' + error.response.data);
                showErrorAlert = true;
            }
        });
    }
}
document.addEventListener('DOMContentLoaded', function() {
    const url = 'http://192.168.251.224:5050/api/user/getalluser';

    axios.get(url)
      .then(function (response) {
            displayUsers(response.data);
        })
      .catch(function (error) {
        });
});
function displayUsers(users) {
    const userListContainer = document.querySelector('.list-std.telo');

    users.forEach(user => {
        const userDiv = document.createElement('div');
        userDiv.className = 'std-flex';

        userDiv.dataset.userId = user.id;

        const innerDiv = document.createElement('div');
        innerDiv.className = 'std-flex';

        const img = document.createElement('img');
        img.src = 'src/images/profile.png';
        img.className = 'profile-img';

        const p = document.createElement('p');
        p.textContent = user.name;

        innerDiv.appendChild(img);
        innerDiv.appendChild(p);

        const buttonsDiv = document.createElement('div');
        buttonsDiv.className = 'button-std';

        const deleteBtn = document.createElement('button');
        deleteBtn.id = 'std_delete';
        deleteBtn.textContent = 'Удалить';

        deleteBtn.addEventListener('click', function() {
            deleteUser(user.id);
        });

        const moreInfoBtn = document.createElement('button');
        moreInfoBtn.id = 'std_more_info';
        moreInfoBtn.textContent = 'Подробнее';

        moreInfoBtn.addEventListener('click', function() {
            showUserDetails(user.id);
        });

        buttonsDiv.appendChild(deleteBtn);
        buttonsDiv.appendChild(moreInfoBtn); 

        userDiv.appendChild(innerDiv);
        userDiv.appendChild(buttonsDiv);

        userListContainer.appendChild(userDiv);
    });
}
function showUserDetails(userId) {
    const urlGetAllUsers = 'http://192.168.251.224:5050/api/user/getalluser ';

    axios.get(urlGetAllUsers)
    .then(function(response) {
            if (response.status === 200) {
                const allUsers = response.data;
                const targetUser = allUsers.find(user => user.id === userId);

                if (targetUser) {
                    let userDetails = `Имя: ${targetUser.name}\n`;
                    userDetails += `Почта: ${targetUser.email}\n`;
                    userDetails += `Пароль: ${targetUser.password}\n`;
                    alert(userDetails);
                } else {
                    alert('Пользователь с таким ID не найден.');
                }
            } else {
                alert('Ошибка при получении списка пользователей.');
            }
        })
    .catch(function(error) {
            console.error(error);
            alert('Произошла ошибка: ' + error.message);
        });
}

function deleteUser(userId) {
    const urlBase = 'http://192.168.251.224:5050/api/user/delete';
    
    axios.delete(`${urlBase}?IdUser=${userId}`)
     .then(function(response) {
            if (response.status === 200) {
                alert('Пользователь успешно удален!');
                location.reload();
            } else {
                alert('Ошибка при удалении пользователя.');
            }
        })
     .catch(function(error) {
            console.error(error);
            alert('Произошла ошибка: ' + error.message);
        });
}
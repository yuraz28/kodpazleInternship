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

    // Добавляем обработчик события для кнопки "Отправить"
    addStdListButton.addEventListener('click', function() {
        closeModalAndSubmit();
    });
});

function closeModalAndSubmit() {
    // Проверяем, заполнены ли все поля
    if (document.getElementById('name_std').value && document.getElementById('mail_std').value && document.getElementById('password_std').value) {
        // Собираем данные из полей ввода
        var name = document.getElementById('name_std').value.trim();
        var email = document.getElementById('mail_std').value.trim();
        var password = document.getElementById('password_std').value.trim();

        // Подготавливаем объект данных
        var user = {
            "name": name,
            "email": email,
            "password": password
        };

        // URL для регистрации пользователя
        var urlRegister = 'http://192.168.161.33:5050/api/user/register';

        // Отправляем запрос на регистрацию пользователя
        axios.post(urlRegister, user, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
     .then(function(response) {
            if (response.status === 201 || response.status === 200) {
                alert('Пользователь успешно зарегистрирован!');
            } else {
                alert('Ошибка при регистрации пользователя.');
            }
        })
     .catch(function(error) {
            console.error(error);
            alert('Произошла ошибка: ' + error.message);
        });
    }
}

document.addEventListener('DOMContentLoaded', function() {
    // URL вашего серверного ресурса
    const url = 'https://yourserver.com/api/data';

    axios.get(url)
       .then(function (response) {
            // Обработка успешного ответа
            console.log(response.data);
            // Здесь вы можете обновить DOM с новыми данными
        })
       .catch(function (error) {
            // Обработка ошибок
            console.error('Ошибка:', error);
        });
});

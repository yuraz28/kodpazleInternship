document.getElementById('entrance').addEventListener('click', function() {
    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value;

    var requestBody = {
        "email": email,
        "password": password
    };

    var urlAuth = 'http://192.168.251.33:5050/api/user/auth';
    var urlRole = 'http://192.168.251.33:5050/api/user/getrole';

    axios.post(urlAuth, requestBody, {
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(function(response) {
        if (response.status === 200) {
            localStorage.setItem('loggedInUser', email);
            return axios.get(urlRole, { params: { email: email } });
        }
        throw new Error('Аутентификация не удалась');
    })
    .then(function(responseRole) {
        var role = responseRole.data;

        var isManager = role === 'Менеджер';    

        if (isManager) {
            window.location.href = 'Manager.html';
        } else {
            window.location.href = 'Backend.html'; 
        }
    })
    .catch(function(error) {
        if (error.response) {
            if (error.response.status === 500) {
                alert('Произошла внутренняя ошибка сервера.');
            } else if (error.response.data === "Неверный пароль") {
                alert('Неверный пароль!');
            } else {
                alert('Пользователь не найден');
            }
        } else {
            console.error(error);
            alert('Произошла ошибка: ' + error.message);
        }
    });
});

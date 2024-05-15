document.getElementById('entrance').addEventListener('click', function() {
    var login = document.getElementById('login').value;
    var password = document.getElementById('password').value;

    var requestBody = {
        "login": login,
        "password": password
    };

    var url = 'http://192.168.161.33:5050/api/user/auth';

    axios.post(url, requestBody)
   .then(function(response) {
        console.log(response.data);
        window.location.href = 'Backend.html';
    })
   .catch(function(error) {
            // Обработка ошибок с кодом статуса 500
            if (error.response && error.response.status === 500) {
                alert('Произошла внутренняя ошибка сервера.');
            } else {
                alert('Пользователь не найден');
            }
        });
});
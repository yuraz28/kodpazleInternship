document.getElementById('entrance').addEventListener('click', function() {
    var login = document.getElementById('login').value;
    var password = document.getElementById('password').value;

    fetch('http://127.0.0.1:5050/api/user/auth', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            login: login,
            password: password
        }),
    })
  .then(response => response.json())
  .then(data => console.log(data))
  .catch((error) => console.error('Error:', error));
});
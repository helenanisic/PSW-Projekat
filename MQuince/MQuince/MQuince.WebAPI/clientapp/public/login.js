var app = new Vue({
    el: '#login',
    data: {
        email: "",
        password:""
    },
    methods: {
        submit: function () {
            axios
                .get('/api/User/',
                    {
                        params:{
                        Email: this.email,
                        Password: this.password
                        }
                    })
                .then(response => {
                    this.info = response.data;
                    localStorage.setItem("access_token", this.info.token);
                    JSAlert.alert("You have successfully logged into your account!");
                    window.location.href = "feedbacks.html";
                    
                })
                .catch(error => {
                    JSAlert.alert(error.response.data);
                });
        }
    }
})

var app = new Vue({
    el: '#login',
    data: {
        email: "",
        password:""
    },
    methods: {
        submit: function () {
            axios
                .get('/api/Patient/Login',
                    {
                        Email: this.email,
                        Password: this.password
                    })
                .then(response => {
                    this.info = response.data
                    JSAlert.alert("You have successfully logged into your account!");
                })
                .catch(error => {
                    console.log(error);
                    if (error.response.status == 400) {
                        JSAlert.alert("Password or email address are incorrect. Please try again.");
                    }
                })
        })
    }
})
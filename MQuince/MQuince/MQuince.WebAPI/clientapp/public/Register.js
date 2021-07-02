var app = new Vue({
    el: '#register',
    data: {
        firstName: "",
        lastName: "",
        telephone: "",
        country: "",
        jmbg: "",
        city: null,
        birthday: null,
        street: null,
        email: "",
        houseNumber: null,
        gender: "",
        lbo: "",
        chosenDoctor: "",
        password: "",
        confirmPassword: "",
        countries: [],
        cities: [],
        doctors: [],
        adressId: "",
        info: ""
    },
    methods: {
        countryChanged: function (event) {
            axios
                .get('/api/City/GetAllCitiesInCountry', {
                    params: {
                        id: event.target.value
                    }
                })
                .then(response => {
                    this.cities = response.data
                })
        },
        submit: function () {
            console.log("Usao")
            axios
                .post('/api/Adress', {
                    Number: parseInt(this.houseNumber),
                    Street: this.street,
                    CityId: this.city
                })
                .then(response => {
                    this.adressId = response.data

                    axios
                        .post('/api/Patient',

                            {
                                Name: this.firstName,
                                Surname: this.lastName,
                                Telephone: this.telephone,
                                Jmbg: this.jmbg,
                                BirthDate: this.birthday,
                                Email: this.email,
                                Password: this.password,
                                UserType: 1,
                                Gender: parseInt(this.gender),
                                ResidenceId: this.adressId,
                                Lbo: this.lbo,
                                ChosenDoctorId: this.chosenDoctor

                            })
                        .then(response => {
                            this.info = response.data
                            JSAlert.alert("You have successfully created an account!");
                            window.location.href = "login.html";
                        })
                        .catch(error => {
                            console.log(error)
                            if (error.response.status == 400) {
                                JSAlert.alert("There is already an account with this email adress");
                            } 
                            
                        })
                
                    
                                
                })
                

        }
    },
    created() {
        
        axios
            .get('/api/Country/GetAll')
            .then(response => {
                this.countries = response.data
            })
        axios
            .get('/api/Doctor/GetAllGenerals')
            .then(response => {
                this.doctors = response.data
            })
    }
    
})
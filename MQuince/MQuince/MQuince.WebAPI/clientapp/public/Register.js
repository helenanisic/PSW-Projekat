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
        street: "",
        email: "",
        houseNumber: "",
        gender: "",
        lbo: "",
        chosenDoctor: "",
        password: "",
        confirmPassword: "",
        countries: [],
        cities: [],
        doctors: [],
        adressId: ""
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
                                UserType: 0,
                                Gender: parseInt(this.gender),
                                ResidenceId: this.adressId,
                                Lbo: this.lbo,
                                ChosenDoctorId: this.chosenDoctor

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
            .get('/api/Doctor/GetAll')
            .then(response => {
                this.doctors = response.data
            })
    }
    
})
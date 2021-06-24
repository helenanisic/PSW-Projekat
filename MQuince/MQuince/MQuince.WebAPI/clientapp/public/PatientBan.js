var app = new Vue({
	el: '#patientBan',
	data: {
		patients: []
	},
	methods: {

	},
	created() {
		axios
			.get('/api/Patient/GetMaliciousPatient', {
				headers: {
					'Authorization': "Bearer " + localStorage.getItem("access_token")
				}
			})
			.then(response => {
				this.patients = response.data
			})

	}
})
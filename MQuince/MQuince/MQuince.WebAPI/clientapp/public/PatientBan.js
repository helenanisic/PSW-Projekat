var app = new Vue({
	el: '#patientBan',
	data: {
		appointments: []
	},
	methods: {

	},
	created() {
		axios
			.get('/api/Appointment/GetAppointmentsForPatient', {
				headers: {
					'Authorization': "Bearer " + localStorage.getItem("access_token")
				}
			})
			.then(response => {
				this.appointments = response.data
			})

	}
})
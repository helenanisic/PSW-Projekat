var app = new Vue({
	el: '#doctor',
	data: {
		referrals: [],
		specializationId: null,
		doctors: [],
		startDate: null,
		endDate: null,
		startTime: null,
		endTime: null,
		doctorId: null,
		appointmentPriority: null,
		referralId: "00000000-0000-0000-0000-000000000000",
		recommendation: null,
		chosenDoctor: null,


		patient: null,
		patients: [],
		medicines: [],
		medicine: null,
		quantity: 0,
		UserRole: ""
	},
	methods: {
		submit: function () {
			axios
				.post('/api/Prescription',

					{
						MedicineId: parseInt(this.medicine.id),
						Patient: this.patient,
						Quantity: parseInt(this.quantity)

					}, {
						headers: {
							'Authorization': "Bearer " + localStorage.getItem("access_token")
						}
				})
				.then(response => {
					JSAlert.alert("Prescription Id: " + response.data);
					alert(response.data);
				})
				.catch(error => {
					console.log(error)
					JSAlert.alert(error.response.data);

				})


		}
	},
	created() {
		axios
			.get('/api/User/GetRole', {
				headers: {
					'Authorization': "Bearer " + localStorage.getItem("access_token")
				}
			})
			.then(response => {
				this.UserRole = response.data
				if (this.UserRole != "Doctor") {
					window.location.href = 'login.html';
				}
				axios
					.get('/api/Patient/GetAllNotBanned', {
						headers: {
							'Authorization': "Bearer " + localStorage.getItem("access_token")
						}
					})
					.then(response => {
						this.patients = response.data;

						axios
							.get('/api/Medicine', {
								headers: {
									'Authorization': "Bearer " + localStorage.getItem("access_token")
								}
							})
							.then(response => {
								this.medicines = response.data;
							})
					})
			})
			.catch(error => {
				console.log(error);
				if (error.response.status == 401) {
					window.location.href = 'login.html';
				}
			})


	}
})
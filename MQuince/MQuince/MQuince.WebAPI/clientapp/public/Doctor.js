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
		quantity: 0
	},
	methods: {
		submit: function () {
			axios
				.post('/api/Prescription',

					{
						MedicineId: parseInt(this.medicine.id),
						Patient: this.patient,
						Quantity: parseInt(this.quantity)

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

	}
})
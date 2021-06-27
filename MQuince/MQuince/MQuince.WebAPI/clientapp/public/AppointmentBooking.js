﻿var app = new Vue({
	el: '#appointmentBooking',
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
		chosenDoctor: null
	},
	methods: {
		specializationChanged: function (event) {
			if (this.specializationId == this.chosenDoctor.specializationId) {
				this.doctors.splice(0, this.doctors.length);
				this.doctors.push(this.chosenDoctor);
				console.log(this.chosenDoctor)
			} else {
				axios
					.get('/api/Doctor/GetDoctorBySpecialization', {
						params: {
							id: this.specializationId
						}
					})
					.then(response => {
						this.doctors = response.data
					})
            }

		},
		submit: function () {
			console.log("Usao")
			for (i = 0; i < this.referrals.length; i++){
				console.log(this.referrals[i].specialization.id);
				console.log(this.specializationId);
				if (this.referrals[i].specialization.id == this.specializationId) {
					console.log("hhh");
					this.referralId = this.referrals[i].id;
					console.log(this.referralId);
				}
			}

			axios
				.post('/api/Appointment/Recommend',

					{
						StartDate: this.startDate,
						EndDate: this.endDate,
						StartTime: parseInt(this.startTime),
						EndTime: parseInt(this.endTime),
						DoctorId: this.doctorId,
						SpecializationId: this.specializationId,
						AppointmentPriority: parseInt(this.appointmentPriority),
						ReferralId: this.referralId

					})
				.then(response => {
					this.recommendation = response.data;
					JSAlert.confirm("On " + this.recommendation.date.substring(0,10) + " at " + this.recommendation.startTime + " with doctor " + this.recommendation.doctorName + this.recommendation.doctorSurname)
						.then(function (result) {
							if (!result)
								return;
						})
				})
				.catch(error => {
					console.log(error)
					JSAlert.alert(error.response.data);

				})


        }
	},
	created() {
		axios
			.get('/api/Appointment/GetReferrals', {
				headers: {
					'Authorization': "Bearer " + localStorage.getItem("access_token")
				}
			})
			.then(response => {
				this.referrals = response.data;
				axios
					.get('/api/Patient/GetChosenDoctor', {
						headers: {
							'Authorization': "Bearer " + localStorage.getItem("access_token")
						}
					})
					.then(response => {
						this.chosenDoctor = response.data;
                    })
			})

	}
})
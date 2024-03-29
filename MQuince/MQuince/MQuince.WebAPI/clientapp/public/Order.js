﻿var app = new Vue({
	el: '#order',
	data: {
		medicine: [],
		pharmacyId: "",
		admin: null,
		changePass: false,
		changeOrder: false,
		changeData: false,
		oldPass: "",
		newPass: "",
		newMedication: [],
		medId: null,
		searchMedicine: "",
		orderMed: null,
		newPrice: "",
		startOfPrice: null,
		endPfPrice: null,
		medQuantity: null,
		orderedMedication: [],
		finishOrder: false,
		deadline: null,
		takeBack: null,
		UserRole: ""
	},
	methods: {
		changeState() {
			if (this.changePass == true) {
				this.changePass = false;

			}
			else
				this.changePass = true;
		},
		discardPassCh() {
			this.finishOrder = false;
		},
		addMedication(m) {
			this.orderMed = m;
			if (this.changeOrder == true) {
				this.changeOrder = false;

			}
			else
				this.changeOrder = true;
		},
		discardPriceCh() {
			this.changeOrder = false;
		},
		defNewOrder() {
			console.log(this.orderedMedication)
			let th = this;
			if (isNaN(this.medQuantity) || !this.medQuantity) {
				JSAlert.alert("Neispravan unos!");
				this.medQuantity = "";
				return;
			}
			console.log(this.orderedMedication)
			for (let i = 0; i < this.orderedMedication.length; i++) {
				if (this.orderedMedication[i].id == this.orderMed.id) {
					console.log(this.medQuantity)
					this.orderedMedication[i].quantity = this.medQuantity;
					const clone = JSON.parse(JSON.stringify(this.orderedMedication));
					this.orderedMedication = clone
					console.log(this.orderedMedication[i].quantity)
					this.changeOrder = false;
					console.log(this.orderedMedication[i])
					return;
				}
			}
			console.log(this.orderedMedication)
			for (let i = 0; i < this.newMedication.length; i++) {
				if (this.newMedication[i].id == this.orderMed.id) {
					this.newMedication.splice(i, 1);
				}
			}
			this.orderMed.quantity = parseInt(this.medQuantity);
			this.orderedMedication.push(this.orderMed);
			this.medQuantity = null;
			this.changeOrder = false;
			console.log(this.orderedMedication)
		},
		formatDate(d) {
			let date = new Date(d)
			return date.getDate() + "." + (date.getMonth() + 1) + "." + date.getFullYear() + ".";
		},
		finish() {
			if (this.finishOrder == true) {
				this.finishOrder = false;

			}
			else
				this.finishOrder = true;


		},
		complete() {
			if (this.orderedMedication.length == 0)
				JSAlert.alert("Your order is empty!");
			axios

				.get('/api/Order',
					
					{
						headers: {
							'Authorization': "Bearer " + localStorage.getItem('access_token')
						},
						params: {
							deadline: this.deadline,
						},
					})
				.then(response => {
					this.errandId = response.data
					for (let i = 0; i < this.orderedMedication.length; i++) {
						this.orderedMedication[i].errandId = this.errandId
					}

					axios
						.post('/api/Order/medications',
							{
								orders: this.orderedMedication
							},
							{
								headers: {
									'Authorization': "Bearer " + localStorage.getItem('access_token')
								}
							})
						.then(response => {

							JSAlert.alert("You have successfully created an order!");
							console.log(this.orderedMedication)
							setTimeout(function () {
								window.location.reload();
							}, 2000);
						}).catch(error => {
							if (error.response.status == 401 || error.response.status == 400 || error.response.status == 500) {
								JSAlert.alert("New order couldn't be made.");
							}
						})
				}).catch(error => {
					if (error.response.status == 401 || error.response.status == 400 || error.response.status == 500) {
						JSAlert.alert(error.response.data.errors[0].defaultMessage);
					}
				})
			console.log(this.orderedMedication)
		},
		deleteFromOrder(m) {
			for (let i = 0; i < this.orderedMedication.length; i++) {
				if (this.orderedMedication[i].id == m.id) {
					this.orderedMedication.splice(i, 1);
				}
			}

			m.quantity = 0;
			this.newMedication.push(m);
		},
		changePrice(m) {
			this.orderMed = m;
			if (this.changeOrder == true) {
				this.changeOrder = false;
			}
			else
				this.changeOrder = true;
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
				if (this.UserRole != "Manager") {
					window.location.href = 'login.html';
				}
				axios
					.get('/api/Medicine', {
						headers: {
							'Authorization': "Bearer " + localStorage.getItem("access_token")
						}
					})
					.then(response => {
						this.newMedication = response.data;
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
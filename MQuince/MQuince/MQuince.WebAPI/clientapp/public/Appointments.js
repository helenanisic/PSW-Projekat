var app = new Vue({
	el: '#appointments',
	data: {
		appointments: []
	},
	methods: {

	},
	created() {
		axios
			.get('/api/Feedback/GetPublishedFeedbacks')
			.then(response => {
				this.appointments = response.data
			})

	}
})
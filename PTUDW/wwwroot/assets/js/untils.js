Untils = new function () {
	this.getCurrentDate = function () {
		const date = new Date();
		let day = date.getDate();
		let month = date.getMonth() + 1;
		let year = date.getFullYear();
		return `${day}/${month}/${year}`;
	}

	this.convertDateView = function (m_date) {
		if (m_date == "" || m_date == null) return "";
		var m_nam = m_date.substring(0, 4);
		var m_thang = m_date.substring(4, 6);
		var m_ngay = m_date.substring(6, 8);
		return m_ngay + "/" + m_thang + "/" + m_nam;
	};
}

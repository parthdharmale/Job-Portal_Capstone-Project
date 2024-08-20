
<template>
  <div class="candidate-signup">
    <h2>Add Candidate</h2>
    <form @submit.prevent="submitForm" class="form">
      <div class="form-group">
        <label for="FirstName">First Name:</label>
        <input type="text" v-model="candidate.FirstName" required />
      </div>

      <div class="form-group">
        <label for="LastName">Last Name:</label>
        <input type="text" v-model="candidate.LastName" required />
      </div>

      <div class="form-group">
        <label for="Email">Email:</label>
        <input type="email" v-model="candidate.Email" required />
      </div>

      <div class="form-group">
        <label for="Password">Password:</label>
        <input type="password" v-model="candidate.Password" required />
      </div>

      <div class="form-group">
        <label for="DOB">Date of Birth:</label>
        <input type="date" v-model="candidate.DOB" required />
      </div>

      <div class="form-group">
        <label for="Address">Address:</label>
        <input type="text" v-model="candidate.Address" required />
      </div>

      <div class="form-group">
        <label for="Contact">Contact:</label>
        <input type="text" v-model="candidate.Contact" required />
      </div>

      <div class="form-group">
        <label for="CityID">City :</label>
        <select v-model="candidate.CityID" id="cityId" required>
                <option value="" disabled>Select City</option>
                <option v-for="city in cities" :key="city.cityID" :value="city.cityID">
                  {{ city.cityName }}
                </option>
              </select>
      </div>

      <div class="form-group">
        <label for="StateID">State :</label>
        <select v-model="candidate.StateID" id="stateId" required>
                <option value="" disabled>Select State</option>
                <option v-for="state in states" :key="state.stateID" :value="state.stateID">
                  {{ state.stateName }}
                </option>
              </select>

      </div>

      <div class="form-group">
        <label for="CountryID">Country :</label>
        <select v-model="candidate.CountryID" id="countryId" required>
                <option value="" disabled>Select Country</option>
                <option v-for="country in countries" :key="country.countryID" :value="country.countryID">
                  {{ country.countryName }}
                </option>
              </select>
      </div>

      <button type="submit">Add Candidate</button>
    </form>

    <div v-if="message" class="message">
      {{ message }}
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      candidate: {
        FirstName: "",
        LastName: "",
        Email: "",
        Password: "",
        DOB: "",
        Address: "",
        Contact: "",
        CityID: null,
        StateID: null,
        CountryID: null,
        // Initialize other fields like Education and Work Experience as needed
      },
      cities: [], 
      states: [],
      countries: [],
      message: "",
    };
  },
  created() {
    // Call getCities when the component is created
    this.getCities();
    this.getStates();
    this.getCountries();
  },
  methods: {
    async submitForm() {
      try {
        const response = await axios.post(
          "https://localhost:7077/api/Candidate/AddCandidate",
          this.candidate
        );
        this.message = response.data; // Handle the success message
      } catch (error) {
        if (error.response && error.response.status === 400) {
          this.message = "Failed to add candidate. Please check the input.";
        } else {
          this.message = "An error occurred. Please try again later.";
        }
        console.error("Error adding candidate:", error);
      }
    },
    async getCities() {
      try {
        const response = await axios.get('https://localhost:7077/api/City/GetAllCities');
        this.cities = response.data;
        console.log(response);
      } catch (error) {
        console.error('Error fetching cities:', error);
      }
    },
    async getStates(){
        try {
        const response = await axios.get('https://localhost:7077/api/State/GetAllStates');
        this.states = response.data;
        console.log(response);
      } catch (error) {
        console.error('Error fetching states:', error);
      }
    },
    async getCountries(){
        try {
        const response = await axios.get('https://localhost:7077/api/Country/GetAllCountries');
        this.countries = response.data;
        console.log(response);
      } catch (error) {
        console.error('Error fetching countries:', error);
      }
    }

  },
};
</script>

<style scoped>
.candidate-signup {
  max-width: 500px;
  margin: 0 auto;
}

.form-group {
  margin-bottom: 15px;
}
.form {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ddd;
  border-radius: 8px;
  background-color: #f9f9f9;
}
.form-group label {
  display: block;
  margin-bottom: 5px;
}

.form-group input {
  width: 100%;
  padding: 8px;
  box-sizing: border-box;
}

button {
  background-color: #007bff;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 16px;
}

.message {
  margin-top: 20px;
  font-weight: bold;
  color: red;
}
</style>

<script setup lang="ts">
import { ref } from 'vue'

const scrapeUrl = ref('')

function searchClick() {
  console.log('click')
}

const scrapedJsonResult = JSON.stringify(
  {
    price: '$100.29',
    price_alt: '$25.99',
    list_price: '$29.99',
    savings: '',
    savings_alt: '$4.00',
    coupon: '',
    subscribe_price: '$23.39 ($7.80 / Fl Oz)',
    subscribe_period:
      '2 weeks 3 weeks 1 month 5 weeks 6 weeks 7 weeks 2 months (Most common) 3 months 4 months 5 months 6 months',
  },
  null,
  2
)
</script>

<template>
  <form class="head-form">
    <h1>Poor Man's Scraper <img src="@/assets/logo.png" class="logo" /></h1>
    <q-input
      v-model="scrapeUrl"
      type="url"
      name="searchUrl"
      class="search"
      input-class="search-input"
      outlined
      placeholder="Enter url to scrape..."
    >
      <template v-slot:after>
        <button type="submit" class="submit-button">
          <q-icon @click="searchClick" name="search" />
        </button> </template
    ></q-input>
  </form>
  <pre class="code"><code>{{ scrapedJsonResult }}</code></pre>
</template>

<style scoped lang="less">
.head-form {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  min-height: 30vh;
}

h1 {
  font-size: 50px;
  font-weight: 200;
  display: flex;
  align-items: center;
  line-height: 55px;
}

.code {
  white-space: pre-wrap;
  border-radius: 15px;
  padding: 1rem;
  background-color: rgb(243, 243, 243);
}

.logo {
  width: 5rem;
}

.search {
  width: 100%;
  max-width: 48rem;
  margin-top: 0.5rem;
}

.submit-button {
  cursor: pointer;
}

@media (min-width: 640px) {
  h1 {
    font-size: 75px;
  }

  .logo {
    width: 7.5rem;
  }
}
</style>

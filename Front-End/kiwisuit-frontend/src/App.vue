<template>
  <HelloWorld msg="Welcome to Kiwi Suit web appilication"/>
  <div id="app">
    <TextField />
  </div>
</template>

<script>
import HelloWorld from './components/Getmethode.vue'

import TextField from "@/components/TextFeild.vue"; // Adjust the import path


export default {
  name: 'App',
  components: {
    HelloWorld,TextField
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>


<template>
  <div>
    <label for="text-input-id">Enter The id:</label>
    <input
      id="text-input-id"
      type="text"
      v-model="inputText"
      @input="handleInput"
      placeholder="Type Id..."
    />

    <label for="text-input-">Enter Text:</label>
    <input
      id="text-input"
      type="text"
      v-model="inputText"
      @input="handleInput"
      placeholder="Type something..."
    />
  </div>
</template>

<script>
export default {
  data() {
    return {
      inputText: '' // This is where the entered text will be stored
    };
  },
  methods: {
    handleInput(event) {
      // This method is triggered when the input field value changes
      this.inputText = event.target.value;
    }
  }
};
</script>

<style scoped>
/* Add your component-specific styles here */
</style>

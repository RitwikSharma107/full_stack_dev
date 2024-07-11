function truncate(str, maxlength) {
    if (str.length > maxlength) {
      return str.slice(0, maxlength - 3) + '...';
    } else {
      return str;
    }
  }
  
  console.log(truncate("What I'd like to tell on this topic is:", 20));
  console.log(truncate("Hi everyone!", 20));                          
  
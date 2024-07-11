function checkEmailId(str) {
    str = str.toLowerCase();
    
    let atIndex = str.indexOf('@');
    let dotIndex = str.indexOf('.', atIndex);
  
    if (atIndex > -1 && dotIndex > -1 && dotIndex > atIndex + 1) {
      return true;
    }
    return false;
  }
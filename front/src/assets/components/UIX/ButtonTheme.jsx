import React from 'react'
import '../UIX/ButtonTheme.css'

export const ButtonTheme = ({ darkMode, toggleTheme }) => {
  return (
    <div className={darkMode ? 'dark' : 'light'}>
<label for="theme" className="theme">
	<span className="theme__toggle-wrap">
		<input id="theme" className="theme__toggle" onChange={toggleTheme}  type="checkbox" role="switch" name="theme" value="dark" />
		<span className="theme__fill"></span>
		<span className="theme__icon">
			<span className="theme__icon-part"></span>
			<span className="theme__icon-part"></span>
			<span className="theme__icon-part"></span>
			<span className="theme__icon-part"></span>
			<span className="theme__icon-part"></span>
			<span className="theme__icon-part"></span>
			<span className="theme__icon-part"></span>
			<span className="theme__icon-part"></span>
			<span className="theme__icon-part"></span>
		</span>
	</span>
</label>
    </div>
  )
}


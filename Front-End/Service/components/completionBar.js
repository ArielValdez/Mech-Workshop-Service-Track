// PlaceHolder componentz
import React from 'react';
import PropType from 'prop-types';

const completionBar = ( { value, max } ) => {
    return (
        <progress value = {value} max = {max} />
    )
};

completionBar.propTypes {
    value: PropTypes.number.isRequired,
    max: PropTypes.number,
}

completionBar.defaultProps {
    value: 0,
    max: 100,
}

export default completionBar;

// Video: https://www.youtube.com/watch?v=3sH_Kq9e5hQ
// Another Video: https://www.youtube.com/watch?v=mT6avAlx-Zg&t=76s

// Using UstStates: https://www.youtube.com/watch?v=AmeoJ7Ngzd4
/* eslint-disable react/prop-types */
import { useState, useEffect } from "react";
import axios from "axios";

function App() {
  const [properties, setProperties] = useState([]);

  useEffect(() => {
    axios
      .get("https://localhost:7083/api/Properties")
      .then((response) => {
        //console.log(response.data);
        setProperties(response.data);
      })
      .catch((error) => console.error(error));
  }, []);

  return (
    <div>
      {properties.map((property, index) => (
        <Property key={index} property={property} />
      ))}
    </div>
  );
}

function Property({ property }) {
  const [isOpen, setIsOpen] = useState(true);

  //console.log(property.transportation);
  //console.log(property.spaces);

  return (
    <div>
      <h2 onClick={() => setIsOpen(!isOpen)}>{property.name}</h2>
      {isOpen && (
        <div>
          <p>Features: {property.features.join(", ")}</p>
          <p>Highlights: {property.highlights.join(", ")}</p>
          <p>
            Transportation:{" "}
            {property.transportation
              .map((item) => JSON.stringify(item))
              .join(", ")}
          </p>
          {property.spaces.map((space, index) => (
            <Space key={index} space={space} />
          ))}
        </div>
      )}
    </div>
  );
}

function Space({ space }) {
  return (
    <div>
      <h3>{space.spaceName}</h3>
      {space.rentRoll.map((rent, index) => (
        <p key={index}>
          {rent.month}: ${rent.rent}
        </p>
      ))}
    </div>
  );
}
export default App;
